# 2DGame

This is a 2D top-down RPG game developed using Unity and C#. The project is structured for development, compilation, and execution on the **Windows** platform. Below are detailed instructions for compiling and running the game, including all necessary prerequisites.

---

## Project Structure
The project directory (`2DGame`) contains the following key components:
- `Assets/`: Contains game assets (sprites, scripts, scenes, etc.).
- `Packages/`: Unity package dependencies.
- `ProjectSettings/`: Unity configuration files.
- `2DGame.sln` and `Assembly-CSharp.csproj`: Solution and project files for C# development.
- `.gitignore` and `.gitattributes`: Git configuration files for version control.
- `Library/`, `Logs/`, `Temp/`, `obj/`: Temporary and cache folders (excluded from version control).

---

## Prerequisites

### General Requirements
- **Unity**: Version 2022.3 or later (LTS recommended for stability). Download from [Unity Hub](https://unity.com/download).
- **Unity Hub**: Central tool for managing Unity projects and editor versions. Download from [Unity Hub](https://unity.com/releases/hub).
- **IDE**: 
  - **Visual Studio Community** (recommended for C# debugging on Windows). Download from [Visual Studio](https://visualstudio.microsoft.com/vs/community/).
  - **Visual Studio Code** (alternative, with C# extension). Download from [VS Code](https://code.visualstudio.com/) and install the C# extension by Microsoft.
- **Git**: For cloning the repository (optional). Download from [Git](https://git-scm.com/downloads).
- **Disk Space**: At least 5GB free for Unity, project files, and build outputs.
- **Operating System**: Windows 10 or later (64-bit).
- **Graphics Drivers**: Ensure GPU drivers are up to date (e.g., NVIDIA, AMD, or Intel) for smooth rendering.
- **DirectX**: Typically pre-installed on Windows 10/11, but ensure DirectX 11 or later is available for Unity’s rendering pipeline.

---

## How to Compile

### Step 1: Set Up the Project
1. **Clone or Download the Repository**:
   - Using Git (if version control is set up):
   git clone https://github.com/hoangfish/2DGame
- Alternatively, download the `2DGame` folder as a ZIP file and extract it to a desired location.
2. **Install Unity Hub**:
- Download and install Unity Hub from [Unity](https://unity.com/releases/hub).
- Open Unity Hub and sign in with a Unity account (free tier is sufficient for personal use).
3. **Install Unity Editor**:
- In Unity Hub, go to **Installs** > **Install Editor**.
- Select Unity 2022.3 (LTS) or a later version.
- Ensure the **Windows Build Support (IL2CPP)** module is included during installation to enable Windows builds.
- Install the editor to your system (default path is fine).
4. **Open the Project in Unity**:
- In Unity Hub, click **Add** in the **Projects** tab.
- Navigate to the `2DGame` folder and select it.
- Click the project name in Unity Hub to open it in the Unity Editor.
5. **Verify Project Integrity**:
- If assets or references are missing, go to **Assets > Reimport All** in the Unity Editor.
- Check the **Console** window for any C# script compilation errors. Open problematic scripts in Visual Studio or VS Code to resolve.

### Step 2: Compile for Windows
1. **Configure Build Settings**:
- In the Unity Editor, go to **File > Build Settings**.
- Select **PC, Mac & Linux Standalone** as the platform.
- Ensure **Target Platform** is set to **Windows**.
- Set **Architecture** to **x86_64** (64-bit, standard for modern Windows systems).
- Optionally, adjust **Compression Method** (e.g., Default or LZ4HC for faster builds).
2. **Build the Project**:
- In the Build Settings window, click **Build**.
- Choose an output directory (e.g., `Builds/Windows/` in the project folder).
- Unity will compile the project, generating:
- An executable file (e.g., `2DGame.exe`).
- A data folder (e.g., `2DGame_Data`) containing game assets and resources.
- The compilation process may take a few minutes, depending on system performance and project size.
3. **Handle Compilation Errors**:
- If the build fails, check the **Console** for errors (e.g., missing assets, script errors).
- Reimport assets via **Assets > Reimport All** if textures or prefabs are missing.
- Ensure all scripts in `Assets/Scripts/` compile without errors by reviewing them in your IDE.
- If errors persist, verify that the **Windows Build Support** module is installed in Unity Hub.

---

## How to Run

### Running in Unity Editor
1. **Load a Scene**:
- In the Unity Editor, open the **Hierarchy** window.
- Ensure a valid game scene is loaded (e.g., `Assets/Scenes/SampleScene.unity`). Double-click the scene file in the **Project** window to load it.
2. **Play the Game**:
- After setting up the project (and ensuring compilation in the editor is successful), click the **Play** button (triangle icon) at the top of the Unity Editor.
- The game will run in the **Game** view, allowing you to test gameplay (e.g., use WASD for movement, mouse for aiming, or other controls defined in `Assets/Scripts/PlayerController.cs`).
- Use the **Scene** view to debug or inspect game objects during play.
3. **Stop Playing**:
- Click the **Play** button again to stop the game and return to editing mode.
- Check the **Console** for any runtime errors or warnings during playtesting.

### Running the Built Executable
1. **Locate the Build Output**:
- Navigate to the output directory specified during the build (e.g., `Builds/Windows/`).
- Ensure the executable (`2DGame.exe`) and the accompanying `2DGame_Data` folder are present in the same directory.
2. **Launch the Game**:
- Double-click the `2DGame.exe` file in the output directory to start the game.
- The game will launch in a standalone window or fullscreen mode, based on the settings configured in **Edit > Project Settings > Player** (e.g., resolution and display mode).
- Upon launching, you’ll see the game’s main menu or initial scene (depending on the project setup), and you can interact with it using the defined controls (e.g., WASD for movement, mouse for aiming, spacebar for actions, as specified in `PlayerController.cs`).
- If a main menu is present, use the mouse or keyboard to navigate options (e.g., Start Game, Settings)

Double-click `2DGame.exe` to run the game on Windows.
- The game will launch in a standalone window or fullscreen, depending on settings configured in **Edit > Project Settings > Player**.
3. **System Requirements**:
- **OS**: Windows 10 or later (64-bit).
- **RAM**: Minimum 4GB (8GB recommended for smooth performance).
- **GPU**: DirectX 11-compatible graphics card (e.g., NVIDIA GTX 960 or equivalent).
- **Storage**: Approximately 1GB for the built game, depending on assets.

---

## Troubleshooting
- **Unity Editor Issues**:
- **Missing Assets**: If textures, scripts, or prefabs are missing, go to **Assets > Reimport All**.
- **Script Compilation Errors**: Open the **Console** window to view errors. Edit problematic scripts in Visual Studio or VS Code (check `Assets/Scripts/`).
- **Packages Missing**: Open **Window > Package Manager** and verify all dependencies listed in `Packages/manifest.json` are installed.
- **Build Issues**:
- **Executable Fails to Run**: Ensure the `2DGame_Data` folder is in the same directory as `2DGame.exe`.
- **Graphics Issues**: Update GPU drivers (e.g., via NVIDIA GeForce Experience or AMD Radeon Software).
- **Build Fails**: Check that **Windows Build Support (IL2CPP)** is installed in Unity Hub. Reinstall if necessary.
- **Performance Issues**:
- Enable **V-Sync** in **Edit > Project Settings > Quality** to prevent screen tearing.
- Reduce graphical settings (e.g., lower resolution or disable effects) in **Edit > Project Settings > Player** for low-end systems.
- Use the **Profiler** (Window > Analysis > Profiler) to identify performance bottlenecks during playtesting.
- **Gameplay Issues**:
- If controls don’t work, verify input mappings in `Assets/Input/InputActions.inputactions` or scripts like `PlayerController.cs`.
- Test gameplay in the Unity Editor first to debug issues before building.

---

## Additional Notes
- **Scripts**: All C# scripts are located in `Assets/Scripts/`. Key files include:
- `PlayerController.cs`: Handles player movement and input.
- `EnemyBase.cs`: Base class for enemy behavior.
- `WeaponFactory.cs`: Manages weapon instantiation.
- **Scenes**: Game scenes are stored in `Assets/Scenes/`. Start with `Sample