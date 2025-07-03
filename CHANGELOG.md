## [1.0.0] - 3. April 2025
### First release

- Figuring out packages
- Adding menu scripts
  - Main Menu
  - Pause Menu

## [1.0.1] - 3. April 2025
### Small fixes

- Fixing the namespaces for the menu scripts


## [1.1.0] - 9. April 2025
### First Update

- Updating the PauseMenu script
  - A PauseMenu prefab was also added
- Adding a MainMenu scene

## [1.1.1] - 9. April 2025
### Bug Fixing

- Sample was improperly setup
  - Now the sample can be imported

## [1.1.2] - 16. April 2025
### Bug Fixing

- Fixed a bug where pause menu wouldn't close, and wouldn't be on top
- Pause menu script namespace

## [1.2.2] - 16. April 2025
### Scene Management

- Added a loading screen
  - Therefore, added a scene loader script to manage scene loading

## [1.2.3] - 18. April 2025
### Pause Menu cursor

- Added a lock state function to the pause menu
  - For game where the cursor is not visible and should be visible when opening the pause menu

## [1.3.0] - 23. April 2025
### Some architecture

- Most of my architecture of what I would be using was done previously so I'm just adding some small stuff
  - GameManager
  - Audio Settings and audio managing
- Edited the README.MD

## [1.3.1] - 24. April 2025
### Audio Settings

- Adding audio settings to the main menu

## [1.3.2] - 24. April 2025
### Miscellaneous scripts from other projects

- A bowling manager
  - Moving the ball and determining at what force it's thrown
  - Can display force in a slider
- Scene preview
  - Place a camera in a scene with a tag PreviewCamera and when the scene is saved, it saves the camera view as a sprite
  - LevelButton script takes the sprite and can showcase it in an image 

## [1.3.3] - 28. April 2025
### Bug Fixing

- Missing sample scene in package 
  - added it now

## [1.4.0] - 6. May 2025
### More pause menu functions

- Added a list of scenes where pause menu shouldn't open
- Added methods to disable and enable pause menu

## [1.5.0] - 12. May 2025
### High score system

- Implemented a high score system
- Simple string and value combo
- Saves it as json in persistent data path
- highscore manager 
  - call AddEntry to add it to the highscores

## [1.5.1] - 9. June 2025
### Bug fix

- fixed a bug in the main menu, where it won't work if there is no pause menu

## [1.6.0] - 11. June 2025
### Dialogue System

- Added an example scene using Yarn Spinner

## [1.6.1] - 15. June 2025

- audio settings slider refresh value if more than one settings is present in game, specifically done for the pause menu

## [1.7.0] - 18. June 2025
### Save System

- added a simple save system
  - Save and load for JSON and PlayerPrefs
  - utility methods

## [1.7.1] - 3. July 2025
### Documentation

- Added documentation to the README file