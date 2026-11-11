BROKEN LEGO BRIDGE DECK V2
Reference dimensions: X length 6.228, Z width 1.908
Four separate deck sections, three real gaps.
Gap width: 0.85 Unity units. Each section length: 0.919.
The rabbit Character Controller radius shown earlier was 0.33 (diameter about 0.66),
so these gaps are wider than the controller diameter.

Unity:
1. Import OBJ and MTL into Assets/Models/Bridge.
2. Keep original deck and v1 as backups.
3. Place v2 at the same Transform as the original deck.
4. Check alignment before disabling the old visual mesh.
5. Disable/replace the old continuous Bridge deck collision; otherwise it will
   invisibly cover the gaps.
6. Add separate colliders to each of the four deck sections.
7. Test in Play Mode and adjust spacing if needed.
Mesh only; not a prefab or full bridge system.
