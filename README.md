# 🦊 The Tiny Fox Adventure

## 1. Project Overview

**Project Name:** The Tiny Fox Adventure  
**Platform:** Unity (2D)  
**Genre:** Platformer / Action  
**Author:** Ana Narmania  
**Course:** IT Step Academy – Game Development (C#, Unity) Sept 2025 - March 2026
**Duration:** 6 months  
**Project Context:** Final project for the second step of the program, showcasing skills learned in C# programming and Unity fundamentals.  
**Version:** 1.0 (Working Demo)  

**Description:**  
The Tiny Fox Adventure is a 2D platformer where the player controls a fox navigating through hazardous levels. Players must avoid enemies and spikes, collect cherries to heal, and gather bullets to attack enemies. The objective is to reach the house at the end of each level. The game has three levels, and completing all levels results in victory.

---

## 2. Gameplay Mechanics

### 2.1 Player

- Max Health: 20  
- Temporary immunity after taking damage: ~3 seconds  
- Can collect bullets to attack enemies (1 damage per bullet)  
- Can collect cherries to restore 5 health  
- **Pause Feature:** Press `P` or click the pause button on touchpad to pause the game  

### 2.2 Enemies & Hazards

| Enemy / Hazard | Damage to Player | Health (Bullets to Kill) |
| -------------- | ---------------- | ------------------------ |
| Frog           | 3                | 3                        |
| Dog            | 4                | 4                        |
| Opossum        | 5                | 5                        |
| Pig            | 6                | 6                        |
| Bear           | 10               | 8                        |
| Spike          | 2                | —                        |

### 2.3 Items

- **Cherry:** Heals 5 health  
- **Bullets:** Collect to shoot enemies (1 damage per bullet)  

### 2.4 Objectives

- Reach the house at the end of each level  
- Complete all 3 levels to win the game  

---

## 3. Controls

| Action | Input                                 |
| ------ | ------------------------------------- |
| Move   | A / D                                 |
| Jump   | W or Space                            |
| Shoot  | Left Control or tap/click on touchpad |
| Pause  | P or tap/click on pause button        |

---

## 4. Level Design

- 3 Levels in total  
- Hazards (spikes) and enemies are placed progressively more difficult  
- Each level ends at a house, which triggers scene change to the next level  

---

## 5. Game Flow

1. Player starts with 20 health and 5 bullets  
2. Collect ammo and cherries, avoid hazards and enemies  
3. Shoot enemies to clear paths  
4. Pause game with `P` or pause button if needed  
5. Reach house → level complete  
6. Repeat until level 3 → game won  

---

## 6. Assets

- **Sprites:** Fox, enemies, spikes, cherries, bullets, house  
- **Animations:** Player movement (idle, run, jump), enemies  
- **Audio:** Background music, jump, collect, shoot, win sounds  
- **UI:** Health bar, ammo count (TextMeshPro), sliders for volume, pause button  

---

## 7. License

- Project is free to use and modify for educational purposes.  
- Sunny Land Asset Pack: https://assetstore.unity.com/packages/2d/characters/sunny-land-103349
- Devnik 2D UI Asset Pack: https://devnik-yt.itch.io/free-2d-pixel-ui-pack-buttons-panels-menus
