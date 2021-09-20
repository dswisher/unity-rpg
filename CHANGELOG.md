## 20-Sep-2021

## [MOVEMENT - Making an RPG in Unity (E01)](https://www.youtube.com/watch?v=S2mK6KFdv0I)

I had some issues importing the assets, and while it looks like there are some fixes in the comments,
there is a lot going on there that I don't understand. So, I'm going to attempt to create a my own
minimalist scene, with placeholder objects made from primitives.

Create a ground, three obstacles, and materials for each.

Adding more to the scene: player, bumps, and a "rover", to experiment with nav mesh obstacle.
Added a simple script to move the rover around a small area.
To get the nav mesh obstacle to work as expected, selecting "Carve" was required.

Added a "Ground" layer, and put the ground and bumps into that layer.
This defines the items that are clickable when using LMB to move, via the `LayerMask` on the `PlayerController`.

Added the `PlayerController`, `PlayerMotor` and `CameraController`, based on the video.


## [INTERACTION - Making an RPG in Unity (E02)](https://www.youtube.com/watch?v=9tePzyL6dgc)

Added the `Interactable` class, plus a new sphere ("Fred") that is interactable (along with Rover).
Enhanced the `PlayerController` and `PlayerMotor` to face the focused interactable, and added a virtual
function for the interaction.

