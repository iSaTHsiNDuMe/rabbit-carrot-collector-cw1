RABBIT SURVIVAL - BROKEN LEGO BRIDGE DECK
==========================================

Files:
- Broken_Brown_LEGO_Bridge_Deck.obj
- Broken_Brown_LEGO_Bridge_Deck.mtl

Design:
- Four separate deck sections.
- Three real open gaps between sections.
- LEGO-style raised studs and darker edge strips.
- Based on the supplied Brown bridge deck tiles.asset bounds:
  X length: 6.228 units
  Y thickness envelope: 0.359 units
  Z width: 1.908 units
- Local origin is centered at (0,0,0).
- Gap width: 0.24 Unity units.

SAFE UNITY INSTALLATION
-----------------------
1. Keep the original Brown bridge deck tiles object and mesh as a backup.
2. Extract the ZIP.
3. Copy the OBJ and MTL into Assets/Models/Bridge/.
4. Wait for Unity to import.
5. Drag the imported OBJ into the scene as a temporary preview.
6. Align it to the existing bridge using the original deck as a visual reference.
7. The OBJ is centered at its local origin. Set the new object's transform to match
   the original deck object's transform, then fine-adjust in Scene view.
8. Once aligned, disable the original Brown bridge deck tiles renderer (do not delete it).
9. IMPORTANT: inspect the existing Bridge deck collision object. The original continuous
   collider will bridge over the holes. Disable it and create separate Box Colliders
   for each of the four deck sections, or use the four visible sections as the basis
   for separate colliders.
10. Test the rabbit crossing before removing/altering any original assets.

This is a replacement visual mesh, not a Unity prefab. It does not include scripts,
colliders, or the group's original bridge rails/supports.
