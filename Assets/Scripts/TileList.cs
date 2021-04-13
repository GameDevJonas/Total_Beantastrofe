using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TileList : MonoBehaviour
{
    public List<ScriptableTile> tiles = new List<ScriptableTile>();

    private void Awake()
    {
        tiles.Clear();
        //DirectoryInfo dir = new DirectoryInfo("Assets/Scripts/Tiles");
        //FileInfo[] info = dir.GetFiles("*.asset");
        //foreach (FileInfo f in info)
        //{
        //    tiles.Add(f.);
        //}

        Object[] obj = Resources.LoadAll("Tiles");
        foreach (ScriptableTile o in obj)
        {
            tiles.Add(o);
        }
    }

    [ContextMenu("Load Tiles")]
    public void LoadTiles()
    {
        tiles.Clear();
        Object[] obj = Resources.LoadAll("Tiles");
        foreach (ScriptableTile o in obj)
        {
            tiles.Add(o);
        }
    }
    [ContextMenu("Clear Tiles")]
    public void ClearTiles()
    {
        tiles.Clear();
    }
}
