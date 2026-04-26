Nightshift is a tense, FNAF-inspired survival horror game built in Unity. Trapped in a pitch-black office, you must manage your limited power supply, monitor security feeds, and utilize blast doors to survive until 6 AM against anomalous, pathfinding snowmen.

🔦 Gameplay Overview
You are confined to a security desk with limited visibility. The facility is completely dark, forcing you to rely on a battery-draining flashlight and a localized security monitor to track enemy movements. If the snowmen breach your office, you lose. Survive the shift, manage your power, and don't let them in.

⚙️ Key Features
Advanced AI Pathfinding: Enemies utilize Unity's NavMesh system to dynamically track the player through a custom-built hallway layout.

Diegetic UI & Interaction: Seamlessly switch between security feeds using physical in-game buttons. Camera labels update dynamically on a World Space Canvas attached to a glowing CRT monitor.

Resource Management System: A custom Game Manager handles power drain logic and a real-time shift clock.

Atmospheric URP Lighting: Built using the Universal Render Pipeline (URP). Features pitch-black ambient lighting, real-time localized point lights, custom emissive materials, and Post-Processing Bloom for neon arcade buttons.

Audio Engineering: Features spatial audio, mechanical interaction sounds (doors, flashlight clicks), and dynamic UI audio feedback.

🎮 Controls
This game utilizes the modern Unity Input System.

Mouse Look: Look around the office.

Left Click (LMB): Interact with buttons (Toggle Doors, Switch Camera Feeds).

Right Click (RMB): Toggle Flashlight.

🛠️ Technical Stack
Engine: Unity 3D (URP)

Language: C#

Key Packages:

Input System

AI Navigation (NavMesh)

TextMeshPro

Post-Processing (Global Volumes/Bloom)

🚀 How to Play (Developer Setup)
If you want to clone this repository and run the project in the Unity Editor:

Clone the repo: git clone https://github.com/YourUsername/Nightshift.git

Open the project folder using Unity Hub. (Ensure you are using a compatible Unity version).

Navigate to Assets/Scenes and open the Main Scene.

Press Play in the editor.
