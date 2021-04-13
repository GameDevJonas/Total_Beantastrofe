using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tile", menuName = "TileType", order = 1)]
public class ScriptableTile : ScriptableObject
{
    public enum TileType { ground, stone}
    public TileType tileName;
    public bool canBeFertile;
}
