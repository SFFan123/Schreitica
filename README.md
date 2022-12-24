# Schreitica
WIP

## Limitations 
- Windows only
- Settingsfile is Computer specific.

## Features
- USB Reading of SNDWAY(R) Sw-525b.
- Raising Events if the set threshold for the DB is exeeded.
- OBS
  - ShowSource on Current Scene
  - HideSource on Current Scene
  - SwitchScene
- Hue
  - TurnOnLight
  - TurnOffLight
  - TurnOnGroup
  - TurnOffGroup

- Saving Settings to %APPDATA%\Schreitica
  - OBS Password is saved encrypted (Computer specific, file entry is not readable on other PC!)
 
 ### Windows/UI
 - Manage UI
   - Polling rate in HZ - how often the USB Device is polled.
   - Threshold
   - OBS Settings Tab
   - Hue Settings Tab
     - Hue Step by Step to add a new user.
   - Action Tree view
     - Drag and Drop to reorder
   - Add
     - Opens Action Add Dialog
   - Removes the selected Action
   
 ## Error Handling
 If an Error occurs while an Action is executed it will be pushed to Windows Notifications.
 
 
 ## Saving Settings
 The Values on the ManageUI will only be passed in the backend if you hit Apply.
 The Settings only get Saved when you hit Save in the Menu > File > Save
