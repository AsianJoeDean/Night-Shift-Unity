# Nightshift
**A survival horror experience developed for CSI 4380 (Winter 2026).**

### 🎮 [Play the WebGL Build on itch.io](INSERT_LINK_HERE)

---

## The Premise
In *Nightshift*, you take on the role of a security guard working a lonely desk in a pitch-black facility. [cite_start]Inspired by the tension of late-night shifts in college residence halls, the game tasks you with surviving until the shift timer runs out. [cite: 98-100, 112]

But you aren't alone. [cite_start]Anomalous snowmen are navigating the dark hallways, and they are heading straight for your office. [cite: 101, 107]

---

## Core Mechanics
* **Resource Management:** You have a limited battery supply. Every time you use your flashlight or close the blast doors, you drain your power. [cite_start]If you hit 0%, you are left in the total dark. [cite: 108-110]
* [cite_start]**Surveillance:** Use the CRT monitor at your desk to toggle between security cameras and track the snowmen as they move toward your position. [cite: 106, 114]
* [cite_start]**Interactive Environment:** The game uses a raycast system, allowing you to interact with physical buttons on your desk to control the facility's security systems. [cite: 105-106, 128-129]

---

## Controls
* [cite_start]**Mouse:** Look around the office. [cite: 184]
* [cite_start]**Left Click (LMB):** Interact with buttons (Doors, Camera Switch). [cite: 128, 183]
* [cite_start]**Right Click (RMB):** Toggle Flashlight. [cite: 173]

---

## Technical Details
* [cite_start]**Unity Version:** 2022.3 (LTS) [cite: 119]
* [cite_start]**Platform:** WebGL [cite: 120]
* [cite_start]**Implementation:** The game uses custom C# scripts for enemy logic, utilizing `Vector3` coordinate math to handle movement and proximity checks. [cite: 126, 150]
* [cite_start]**Optimized Lighting:** We used a point-light "hack" for the emissive buttons to maintain a high frame rate while keeping the atmosphere pitch black. [cite: 133-134]

---

## Development Team
* **Joe Dean**
* **Michael Berceli** 

*Developed as a term project at Oakland University.*

***
