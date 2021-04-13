using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int[,] grid;

    public int gridSizeX, gridSizeY;

    public float spriteSizeX, spriteSizeY;

    public GameObject tilePrefab;

    public bool firstLineFertile;

    void Start()
    {
        firstLineFertile = true;
        grid = new int[gridSizeX, gridSizeY];
        for (int i = 0; i < gridSizeX; i++)
        {
            for (int j = 0; j < gridSizeY; j++)
            {
                SpawnTile(i, j);
                if(j == gridSizeY - 1)
                {
                    firstLineFertile = false;
                }
            }
        }
    }

    void SpawnTile(int x, int y)
    {
        GameObject g = Instantiate(tilePrefab);
        g.transform.SetParent(this.transform);
        g.transform.localPosition = new Vector3(x * spriteSizeX, y * spriteSizeY);
        g.GetComponent<TileInfo>().gridPosition = new Vector2(x, y);
        g.name = x + ", " + y;
        if (firstLineFertile)
        {
            g.GetComponent<TileInfo>().fertility = 1;
        }
    }
}
