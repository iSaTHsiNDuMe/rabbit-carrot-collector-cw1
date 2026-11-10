# Member 4 handover

Open **RabbitSurvivalLEGO** in Unity 6000.6.4f1 and press **Play**.

1. Click **Play rabbit walk** in the bottom left of the Game tab. The white rabbit plays a short bounce and squash animation. The character controller and camera stay on the rabbit root.
2. Use **WASD** to walk, **Space** to jump, and **C** to toggle mouse look. Press **Esc** to release the cursor for the button.
3. Watch the Olive Ranger and Orange Scout follow their four existing waypoints. Use a hiding bush to avoid being caught. An exposed rabbit that comes within reach of a hunter is returned to the starting trail.
4. Cross the bridge and approach the cave. When the game says **Press 1 to open the cave**, press the number **1** above the letters. The animated brick array starts in `Rest`, plays `Explode`, then holds `Explode Rest`. The doorway collider switches off once the bricks finish moving.
5. Walk up to the black rabbit. The cave trigger checks that the white rabbit entered after the wall opened and displays **You found the second rabbit!**.

In the Hierarchy, select **Rabbit 01 - White** to find the rabbit's Animator and **Student4RabbitWalk** component. Select **Student 4 rabbit walk button** to see the connection under **Button → On Click**. Select **8BrickArrayExplode** to see the wall controller and key action. Select either hunter to see its four waypoint references. Select **Student 4 cave win trigger** to see the trigger and its rabbit, wall, and status references.

The walk uses the white rabbit model at the user's request. Confirm whether this substitution satisfies the lecturer's separate minifigure requirement. The carrot counter and its link to hunter activation are a Member 2 integration item. The Member 4 test starts on the trail and does not require a carrot counter.

## Report preparation

- **6. Project management.** Explain the group task split and the handoff between the player controller, patrols, bridge and cave. Add the branch or commit your group actually used, an example of a real decision from your meeting notes, and your own test result. Use the dates from your records.
- **7. Commercial analysis.** Compare the animal viewpoint and encounter design with [Untitled Goose Game](https://goose.game/), and the use of brick forms and spatial puzzles with [LEGO Builder’s Journey](https://www.lightbrick.com/builders-journey). Describe the intended players for Rabbit Survival, why a short PC prototype suits them, and what you would playtest before discussing a release. Explain that branded and course-supplied assets need a rights review for any commercial release. [LEGO Fair Play guidance](https://www.lego.com/en-us/legal/notices-and-policies/fair-play)
- **8. AI code assist.** Record that Codex helped wire the Animator states, write the rabbit walk button and patrol scripts, and test the wall and cave in Unity. Separate your design decisions and manual checks from the generated changes. Include the actual chat transcript and describe one result you reproduced yourself. Use the course brief's disclosure format.

## Test evidence

The Play mode checks invoke the walk button and inspect the visual transform. They sample both hunters at different frames, place the player at the reunion point while the wall is closed, then test the cave key near the door and enter the goal after it opens. These are checks of the individual features. Record your own full run from the starting trail for the group video.


The final run measured 0.10 units of vertical movement on the rabbit visual and movement by both hunters between samples. The goal stayed inactive while the wall was closed. After the test sent the 1 key, the doorway collider disabled and the reunion trigger displayed the win message. See [the starting trail](PlayTests/01-rabbit-at-trail-start.png) and [the cave win](PlayTests/02-cave-reunion.png).

## Meeting records

Use the [meeting notes template](MeetingNotes/Template.md) for a meeting your group actually held. Store real minutes and evidence under this GroupWork folder. Keep your personal coursework files in the individual folder named in the brief.
