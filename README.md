# Game A Week toolkit 

This is a package with useful stuff for fast development for the course Game A Week.

Documentation of what I did will be in the changelog.

# !!! Important !!!

Install the sample Loading Screen. It was put in as a sample so the loading screen can be modified.

# Documentation

Generally for prefabs, if you want to modify a prefab duplicate the prefab and save it in your Assets folder somewhere.

## Audio System

An audio system that controls audio of the game through Master volume, Music volume and Sound Effects volume

- **AudioSettings script**
    - should be present in a canvas and drag in the sliders used to control the volume
- **AudioManager script**
    - Should be on a completely seperate object, it is a singleton so it will persist through scenes
    - Drag in the relevant AudioMixer with exposed variables
        - There is mixer present you can use that as a template
        - if you don't want to use the mixer that is


## Highscore System

- **HighScoreConfig script**
    - a script for configuration of the highscore table
    - also a scriptable object to put in the Manager 
- **HighScoreManager**
    - Call the public method AddEntry to add an entru into the highscore table

## Menu and Scene management

If you ever want to load a scene not using these scripts, do it through SceneLoader.LoadScene(targetScene).

- **MainMenu script**
    - Place this script on the root canvas object of where the menu is
    - contains methods:
        - To load a scene
        - to reload a scene (restart)
        - to quit the application

- **SceneLoader**
    - a helper class to load into the loading scene with the information of the target scene to load
    - There should always be a scene with the name of LoadingScene
- **LoadingScreenManager**
    - manages the loading screen
    - updates a progress bar for the loading progress
    - asynchroniously it loads the target scene set by the SceneLoader

- **PauseMenu**
    - should be present on the root object of the pause menu object, since it's a persistent object
    - You can set if the cursor should be locked/unlocked when closing/opening the pause menu by ticking the Lock Cursor field
    - Forbidden scenes list used for scenes where you don't want the pause menu be able to open
    - DisablePauseMenu, EnablePauseMenu
        - call by getting the PauseMenu.Instance.method
        - can be used so that pause menu is not able to be opened in desired situations
            - don't forget to Enable the pause menu at some point after disabling it

- **ScrollAutoRect**
    - used for when you want your UI to be usable with the controller and you have a scrollable window somewhere
    - Put this on the object that has the ScrollRect component


## Save System

Checkout in the SaveSystemExamples scripts, how the save system could be used.

- **SaveSystem script**
    - containts methods to load and save with prefabs and JSON
    - also includes some helper methods
    - you can create your own data structure and use save with JSON that
    - check out the SaveSystemExamples script 


## Miscellaneous scripts

### Bowling Manager

A simple manager for bowling I created.
You can use this script to move the ball left and right to aim.
You can also charge with how much power the ball is thrown. That can be displayed in a slider on a ui.
You might need to update it for however you want to you use it. Use it as a template/starting point.

### Scene Preview

Creates a preview sprite image from a preview camera. Can bu used to speed up taking images of a level for a level selector. Still is a bit manual but saved me a lot of time.

- Needs a PreviewCamera tag
- put that tag on a an object with the camera component
- position the camera in the way you want it to take the image
- when you save the scene (ctrl+s) it saves the image in Assets/Resources/LevelPreviews
- you can change the resolution of the image that is taken
- you can change the location to where it is saved, i would recommend to keep it in the Resources folder

## Cheat Console

A joker was taken here