using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour
{
    public ScriptableTile.TileType currentType;

    public Vector2 gridPosition;
    public bool planted, canBeFertile, hasBush;

    [Range(0,1)]
    public float fertility;

    public TileList list;

    public CurrencySystem currency;
    private float generatingTimer;

    private Animator anim;
    public ScriptableTile currentTile;

    private void Awake()
    {
        generatingTimer = Random.Range(-10, 1);
        currency = FindObjectOfType<CurrencySystem>();
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
        if(fertility < 0)
        {
            fertility = 0;
        }
        if(fertility > 1)
        {
            fertility = 1;
        }

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
        //GetComponent<Collider2D>().enabled = !planted;
        anim.SetFloat("Fertility", fertility);

        if (fertility >= .9f)
        {
            CurrencyGenerating();
        }
        else
        {
            generatingTimer = Random.Range(-10, 1);
        }
    }

    public void CurrencyGenerating()
    {
        if(generatingTimer >= currency.generatingInterval)
        {
            GameObject prefab = Instantiate(currency.currencyPrefab, transform.position, Quaternion.identity);
            prefab.transform.position = new Vector3(prefab.transform.position.x, prefab.transform.position.y, -3);
            //prefab.GetComponent<CurrencyPrefab>().value = currency.generateAmount;
            Destroy(prefab, currency.prefabTime);
            generatingTimer = Random.Range(-10, 1);
        }
        else
        {
            generatingTimer += Time.deltaTime;
        }
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
