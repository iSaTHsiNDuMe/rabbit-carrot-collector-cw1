RABBIT SURVIVAL - FALLING ROCK MESHES
=====================================

Contents:
- Rock_Small.obj / Rock_Small.mtl
- Rock_Medium.obj / Rock_Medium.mtl
- Rock_Heavy.obj / Rock_Heavy.mtl

Import into Unity:
1. Extract this folder.
2. Copy the three .obj and matching .mtl files into your Unity project's Assets/Models/FallingRocks folder.
3. Unity will import the OBJ meshes and their material definitions.
4. If the material does not import automatically, create a URP/Lit material and use a medium stone-grey base colour.
5. Add a Box Collider (or Mesh Collider) and Rigidbody to a scene instance/prefab.
6. For a moving rock, use a non-kinematic Rigidbody. Do not put a Rigidbody on the rabbit's Character Controller.

Scale:
The meshes are modelled in approximate metre units and have their origin around the bottom centre.
They are low-poly, block-built placeholder meshes designed to fit a LEGO-style environment.
