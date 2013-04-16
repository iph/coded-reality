coded-reality
=============

----------------------
Zach - Monday, Mar 4

We have a lot of prefabs to work with for templating levels. **Don't try to reinvent the prefab** (it'll break our ability to use git), just instantiate (by dragging from assets->hierachy) and adjust that one if needed. Pretty much any room should be able to be made by combining **'Walls', 'Frames', and 'Doors'** (Active or Inactive). Start with a template- AllDoors, ClosedBox, DoorFrames- then remove walls/frames and add the opposite, add doors, etc.

To keep working with Git easy, work on a **seperate scene** and a **seperate branch**. Then we should be able to merge without much hassle.
 
----------------------
Zach - Monday, Mar 4

Unity help:

If you have issues compiling and running the project after pulling from Github, try these steps:

* 1. Delete the offending objects (they're the ones with missing/uncompiled Mono Scripts)
* 2. Reimport the things that weren't working (like FirstPersonController)
* 3. Save
* 4. Quit and reopen Unity
* 5. It should work!

Step 1 might not be necessary. Save as and then copy in the other stuff if you want to preserve your stuff.

-------------------------
