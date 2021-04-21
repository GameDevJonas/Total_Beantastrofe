using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    public ScriptableTile.TileType currentType;

    public Vector2 gridPosition;
    public bool planted, canBeFertile;

    [Range(0,1)]
    public float fertility;

    public TileList list;

    private Animator anim;
    public ScriptableTile currentTile;

    private void Awake()
    {
        list = FindObjectOfType<TileList>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        
        //LoadInfo(list.tiles[0]);
    }

    public void UpdateGridPosition(int x, int y)
    {
        gridPosition = new Vector2(x, y);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentType != currentTile.tileName)
        {
            switch (currentType)
            {
                case ScriptableTile.TileType.ground:
                    LoadInfo(list.tiles[0]);
                    break;
                case ScriptableTile.TileType.stone:
                    LoadInfo(list.tiles[1]);
                    break;
            }
        }

        anim.SetFloat("Fertility", fertility);
    }

    public void LoadInfo(ScriptableTile tile)
    {
        currentTile = tile;
        canBeFertile = tile.canBeFertile;
        currentType = tile.tileName;

        //Tile ID
        switch (currentType)
        {
            case ScriptableTile.TileType.ground:
                anim.SetInteger("TileID", 0);
                break;
            case ScriptableTile.TileType.stone:
                anim.SetInteger("TileID", 1);
                break;
        }
    }
}
