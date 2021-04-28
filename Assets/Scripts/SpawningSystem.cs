using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningSystem : MonoBehaviour
{
    public float gracePeriod;
    public float progress;

    public List<Transform> spawnPoints = new List<Transform>();
    public List<EnemyPool> enemies = new List<EnemyPool>();

    public List<RoundTimerInfo> roundInfo = new List<RoundTimerInfo>();
    private Queue<RoundTimerInfo> info = new Queue<RoundTimerInfo>();
    private float nextProgress;

    float spawnInterval;
    int spawnCountMin, spawnCountMax;
    float spawnTimer;
    private float graceTimer;
    private GridManager grid;
    private float maxProgress, currentProgress;
    private List<TileInfo> totalTiles = new List<TileInfo>();

    bool inSpawn;


    // Start is called before the first frame update
    void Start()
    {
        graceTimer = gracePeriod;
        grid = FindObjectOfType<GridManager>();
        foreach (RoundTimerInfo i in roundInfo)
        {
            info.Enqueue(i);
        }
        Invoke("Initiate", .1f);
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
        CheckForFertility();
        CheckForNextEvent();
        if (graceTimer <= 0)
        {
            if (spawnTimer <= 0 && !inSpawn)
            {
                StartCoroutine(SpawnTimer());
            }
            else
            {
                spawnTimer -= Time.deltaTime;
            }
        }
        else
        {
            graceTimer -= Time.deltaTime;
        }
    }

    public void CheckForNextEvent()
    {
        if (progress >= nextProgress)
        {
            spawnInterval = info.Peek().enemySpawningInterval;
            spawnCountMin = info.Peek().enemySpawningCountMin;
            spawnCountMax = info.Peek().enemySpawningCountMax;
            if (info.Count > 1)
            {
                info.Dequeue();
                nextProgress = info.Peek().progressAmount;
            }
            else
            {
                nextProgress = 1.1f;
            }
        }
    }

    void CheckForFertility()
    {
        currentProgress = 0;
        foreach (TileInfo tile in totalTiles)
        {
            currentProgress += tile.fertility;
        }
        progress = currentProgress / maxProgress;
    }

    IEnumerator SpawnTimer()
    {
        inSpawn = true;
        int max = Random.Range(spawnCountMin, spawnCountMax + 1);
        for (int i = 0; i < max; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
        spawnTimer = spawnInterval;
        inSpawn = false;
        yield return null;
    }

    public void SpawnEnemy()
    {
        Transform point = spawnPoints[Random.Range(0, spawnPoints.Count)];
        EnemyPool enemy = enemies[Random.Range(0, enemies.Count)];
        if (enemy.weight > progress) SpawnEnemy();
        GameObject clone = Instantiate(enemy.enemy, point.position, Quaternion.identity);
    }
}

[System.Serializable]
public class EnemyPool
{
    public GameObject enemy;
    public int weight;
}

[System.Serializable]
public class RoundTimerInfo
{
    public float progressAmount;
    public float enemySpawningInterval;
    public int enemySpawningCountMin, enemySpawningCountMax;
}
