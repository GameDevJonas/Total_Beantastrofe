using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private GridManager grid;
    public int health;
    public int cost;
    public float cooldownTime;
    public float abilityTimerSet;
    private float abilityTimer;
    public int damage;
    public Vector2 aoe;
    [HideInInspector]
    public Vector2 myTile;
    public float fertilizeValue;
    public float fertilizeTimerSet;
    [HideInInspector]
    public float fertilizeTimer;
    public Vector2 fertilizeRange;
    //public TileInfo[,] fertilizeTiles;
    public bool onlyAdjacent;
    public List<TileInfo> fertilityTileList = new List<TileInfo>();
    public Animator myAnim;
    public enum PlantStage { first, second, third };
    public PlantStage myStage;

    public void Start()
    {
        grid = FindObjectOfType<GridManager>();
        myTile = GetComponentInParent<TileInfo>().gridPosition;
        fertilizeTimer = fertilizeTimerSet;
        for (int i = 0; i < fertilizeRange.x; i++)
        {
            for (int j = 0; j < fertilizeRange.y; j++)
            {
                if (((int)myTile.x - 1 + i) >= 0 && ((int)myTile.y - 1 + j) >= 0 && ((int)myTile.x - 1 + i) <= grid.gridSizeX - 1 && ((int)myTile.y - 1 + j) <= grid.gridSizeY - 1)
                    if (onlyAdjacent)
                    {
                        if ((i == 0 && j == 0) || 
                            (i == 0 && j == fertilizeRange.y - 1) || 
                            (i == fertilizeRange.x - 1 && j == 0) || 
                            (i == fertilizeRange.x - 1 && j == fertilizeRange.y - 1))
                        {

                        }
                        else
                        {
                                fertilityTileList.Add(grid.tileGrid[(int)myTile.x - 1 + i, (int)myTile.y - 1 + j]);
                        }
                    }
                    else
                    {
                            fertilityTileList.Add(grid.tileGrid[(int)myTile.x - 1 + i, (int)myTile.y - 1 + j]);
                    }
            }
        }
    }

    public void Update()
    {
        AbilityTimer();
        Fertilizing();
    }

    public void AbilityTimer()
    {
        if (abilityTimer <= 0)
        {
            DoAbility();
            abilityTimer = abilityTimerSet;
        }
        else
        {
            abilityTimer -= Time.deltaTime;
        }
    }

    public virtual void DoAbility()
    {
        Debug.LogError("This should never show up >:(");
    }

    public void Fertilizing()
    {
        if (fertilizeTimer <= 0)
        {
            DoFertilize();
            fertilizeTimer = fertilizeTimerSet;
        }
        else
        {
            fertilizeTimer -= Time.deltaTime;
        }
    }

    public void DoFertilize()
    {
        foreach (TileInfo tile in fertilityTileList)
        {
            tile.fertility += fertilizeValue;
        }
    }

    public void OnWater()
    {
        if(myStage == PlantStage.first)
        {
            //Evolve animasjon
            GetComponentInChildren<Animator>().SetTrigger("Upgrade");
            myStage = PlantStage.second;
        }
        else if(myStage == PlantStage.second)
        {
            myStage = PlantStage.third;
        }
    }
}
