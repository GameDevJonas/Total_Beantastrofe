using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    public float deFValue;
    public bool hasDeF;
    private GridManager grid;
    public Vector2 posInGrid;
    public int nextPosition;
    public List<TileInfo> tilesInRange = new List<TileInfo>();
    public enum Range { self, around, front }
    public Range range;
    public Animator anim;
    public bool instakillPlant;
    public bool placeholderWalking;

    private void Awake()
    {
        grid = FindObjectOfType<GridManager>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        nextPosition = (int)posInGrid.x - 1;
        CheckForTilePos();

        if (placeholderWalking)
        {
            MoveMe();
        }

        if(health <= 0)
        {
            Die();
        }
    }

    public void UpdateTiles()
    {
        tilesInRange.Clear();
        switch (range)
        {
            case Range.self:
                tilesInRange.Add(grid.tileGrid[(int)posInGrid.x, (int)posInGrid.y]);
                break;
            case Range.around:
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (((int)posInGrid.x - 1 + i) >= 0 && ((int)posInGrid.y - 1 + j) >= 0 && ((int)posInGrid.x - 1 + i) <= grid.gridSizeX - 1 && ((int)posInGrid.y - 1 + j) <= grid.gridSizeY - 1)
                            tilesInRange.Add(grid.tileGrid[(int)posInGrid.x - 1 + i, (int)posInGrid.y - 1 + j]);
                    }
                }
                break;
            case Range.front:
                for (int i = 0; i < 1; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (((int)posInGrid.x - 1 + i) >= 0 && ((int)posInGrid.y - 1 + j) >= 0 && ((int)posInGrid.x - 1 + i) <= grid.gridSizeX - 1 && ((int)posInGrid.y - 1 + j) <= grid.gridSizeY - 1)
                            tilesInRange.Add(grid.tileGrid[(int)posInGrid.x - 1 + i, (int)posInGrid.y - 1 + j]);
                    }
                }
                break;
        }
    }

    public void CheckForTilePos()
    {
        if (transform.position.x <= grid.tileGrid[(int)posInGrid.x, (int)posInGrid.y].transform.position.x && !hasDeF)
        {
            DeFertilize();
            if (grid.tileGrid[(int)posInGrid.x, (int)posInGrid.y].planted)
            {
                Destroy(grid.tileGrid[(int)posInGrid.x, (int)posInGrid.y].GetComponentInChildren<Plant>().gameObject);
                grid.tileGrid[(int)posInGrid.x, (int)posInGrid.y].planted = false;
            }
        }
    }

    public void DeFertilize()
    {
        foreach (TileInfo tile in tilesInRange)
        {
            tile.fertility -= deFValue;
        }
        hasDeF = true;
    }

    public void MoveMe()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-speed * Time.deltaTime, 0f);
    }

    public void DamageMe(int damage)
    {
        health -= damage;
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tile"))
        {
            posInGrid = collision.GetComponent<TileInfo>().gridPosition;
            hasDeF = false;
            UpdateTiles();
        }
    }
}
