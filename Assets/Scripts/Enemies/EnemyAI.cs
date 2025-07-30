using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float roamChangeDirFloat = 2f;
    [SerializeField] private float attackRange = 0f;
    [SerializeField] private MonoBehaviour enemyType;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private bool stopMovingWhileAttacking = false;

    private EnemyPathfinding enemyPathfinding;
    private IEnemyState currrentState;
    private float timeRoaming = 0f;
    private bool canAttack = true;

    // Public getters
    public float RoamChangeDirFloat => roamChangeDirFloat;
    public float AttackRange => attackRange;
    public IEnemy EnemyType => enemyType as IEnemy;
    public float AttackCooldown => attackCooldown;
    public bool StopMovingWhileAttacking => stopMovingWhileAttacking;
    public EnemyPathfinding Pathfinding => enemyPathfinding;
    public Transform Player => PlayerController.Instance.transform;
    public bool CanAttack => canAttack;

    private void Awake()
    {
        enemyPathfinding = GetComponent<EnemyPathfinding>();
    }

    private void Start()
    {
        SetState(new EnemyRoamingState());
    }

    private void Update()
    {
        currrentState?.UpdateState(this);
    }

    public void SetState(IEnemyState newState)
    {
        currrentState?.ExitState(this);
        currrentState = newState;
        currrentState.EnterState(this);
    }

    public Vector2 GetRoamingPosition()
    {
        timeRoaming = 0f;
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    public bool IsPlayerInRange()
    {
        return Vector2.Distance(transform.position, Player.position) < attackRange;
    }

    public void PerformAttack()
    {
        if (!CanAttack) return;

        canAttack = false;
        EnemyType?.Attack();

        if (StopMovingWhileAttacking)
            Pathfinding.StopMoving();
        else
            Pathfinding.MoveTo(Player.position);

        StartCoroutine(AttackCooldownRoutine());
    }

    private IEnumerator AttackCooldownRoutine()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    // ---------- Nested State Interfaces and Implementations ----------

    public interface IEnemyState
    {
        void EnterState(EnemyAI enemy);
        void UpdateState(EnemyAI enemy);
        void ExitState(EnemyAI enemy);
    }

    public class EnemyRoamingState : IEnemyState
    {
        private Vector2 roamPosition;
        private float timeRoaming = 0f;

        public void EnterState(EnemyAI enemy)
        {
            roamPosition = enemy.GetRoamingPosition();
            enemy.Pathfinding.MoveTo(roamPosition);
        }

        public void UpdateState(EnemyAI enemy)
        {
            timeRoaming += Time.deltaTime;

            enemy.Pathfinding.MoveTo(roamPosition);

            if (enemy.IsPlayerInRange())
            {
                enemy.SetState(new EnemyAttackingState());
                return;
            }

            if (timeRoaming > enemy.RoamChangeDirFloat)
            {
                roamPosition = enemy.GetRoamingPosition();
                enemy.Pathfinding.MoveTo(roamPosition);
                timeRoaming = 0f;
            }
        }

        public void ExitState(EnemyAI enemy) { }
    }

    public class EnemyAttackingState : IEnemyState
    {
        public void EnterState(EnemyAI enemy)
        {
            if (enemy.StopMovingWhileAttacking)
                enemy.Pathfinding.StopMoving();
        }

        public void UpdateState(EnemyAI enemy)
        {
            if (!enemy.IsPlayerInRange())
            {
                enemy.SetState(new EnemyRoamingState());
                return;
            }

            if (enemy.CanAttack)
            {
                enemy.PerformAttack();
            }
        }

        public void ExitState(EnemyAI enemy) { }
    }
}