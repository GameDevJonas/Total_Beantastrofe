using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public float progress;
    private List<TileInfo> totalTiles = new List<TileInfo>();
    private GridManager grid;
    private float maxProgress, currentProgress;
    public bool gameEnded;
    public GameObject winScreen, loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        grid = FindObjectOfType<GridManager>();
        Invoke("Initiate", .1f);
        winScreen = GameObject.Find("WinScreen");
        loseScreen = GameObject.Find("LoseScreen");
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    public void Initiate()
    {
        foreach (TileInfo tile in grid.tileGrid)
        {
            if (tile.currentType == ScriptableTile.TileType.ground)
            {
                totalTiles.Add(tile);
            }
        }
        maxProgress = totalTiles.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameEnded) CheckForFertility();
        if (gameEnded && progress >= 1) StartWinGame();
    }

    void CheckForFertility()
    {
        currentProgress = 0;
        foreach (TileInfo tile in totalTiles)
        {
            currentProgress += tile.fertility;
        }
        progress = currentProgress / maxProgress;
        if (progress >= 1) gameEnded = true;
    }

    public void LoseGame()
    {
        //You lost lmao
        gameEnded = true;
        GetComponent<SpawningSystem>().enabled = false;
        foreach(Enemy enemy in FindObjectsOfType<Enemy>())
        {
            Destroy(enemy.gameObject);
        }
        foreach(TileInfo tile in FindObjectsOfType<TileInfo>())
        {
            tile.enabled = false;
        }
        foreach(Plant plant in FindObjectsOfType<Plant>())
        {
            plant.enabled = false;
        }
        loseScreen.SetActive(true);
    }

    public void StartWinGame()
    {
        GetComponent<SpawningSystem>().enabled = false;
        if(FindObjectsOfType<Enemy>().Length <= 0)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        //You win yay
        foreach (TileInfo tile in FindObjectsOfType<TileInfo>())
        {
            tile.enabled = false;
        }
        foreach (Plant plant in FindObjectsOfType<Plant>())
        {
            plant.enabled = false;
        }
        winScreen.SetActive(true);
    }
}
