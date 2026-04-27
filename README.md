# Nightshift
**A survival horror experience developed for CSI 4380 (Winter 2026).**

### 🎮(https://jdean33.itch.io/nightshift)

---

## The Premise
In *Nightshift*, you take on the role of a security guard working a lonely desk in a pitch-black facility. Inspired by the Five Nights At Freddy's, the game tasks you with surviving until the shift timer runs out. 
But you aren't alone. Anomalous snowmen are navigating the dark hallways, and they are heading straight for your office.

---

## Core Mechanics
* **Resource Management:** You have a limited battery supply. Every time you use your flashlight or close the blast doors, you drain your power. If you hit 0%, you are left in the total dark. 
* **Surveillance:** Use the CRT monitor at your desk to toggle between security cameras and track the snowmen as they move toward your position. 
* **Interactive Environment:** The game uses a raycast system, allowing you to interact with physical buttons on your desk to control the facility's security systems.

---

## Controls
* **Mouse:** Look around the office. 
* **Left Click (LMB):** Interact with buttons (Doors, Camera Switch). 
* **Right Click (RMB):** Toggle Flashlight. 

---

## Technical Details
* **Unity Version:** 2022.3 (LTS) 
* **Platform:** WebGL 
* **Implementation:** The game uses custom C# scripts for enemy logic, utilizing `Vector3` coordinate math to handle movement and proximity checks.
* **Optimized Lighting:** We used a point-light "hack" for the emissive buttons to maintain a high frame rate while keeping the atmosphere pitch black. 
---

## Development Team
* **Joe Dean**
* **Michael Berceli** 

*Developed as a term project at Oakland University.*

***
