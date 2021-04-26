using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : Plant
{
    public GameObject bush;
    public List<GameObject> bushes = new List<GameObject>();

    private Queue<TileInfo> tilesToBush = new Queue<TileInfo>();
    public TileInfo[] queueVisual;
    private bool startedBushes = false;

    private void Awake()
    {
        fertilizeTimer = fertilizeTimerSet;

    }

    public override void DoAbility()
    {
        if (tilesToBush.Count < 1 && !startedBushes)
        {
            foreach (TileInfo tile in fertilityTileList)
            {
                if (tile.gridPosition != myTile)
                    tilesToBush.Enqueue(tile);
            }
        }


        if (startedBushes)
        {
            if (tilesToBush.Count < 1) return;
        }

        if (tilesToBush.Peek().fertility < .9f)
        {
            return;
        }

        if (tilesToBush.Peek().hasBush)
        {
            tilesToBush.Dequeue();
            return;
        }
        Transform t = tilesToBush.Peek().transform;

        GameObject bushClone = Instantiate(bush, t);
        tilesToBush.Peek().hasBush = true;
        bushes.Add(bushClone);
        tilesToBush.Dequeue();
        startedBushes = true;
        queueVisual = tilesToBush.ToArray();
    }

    private void OnDestroy()
    {
        foreach (GameObject bush in bushes)
        {
            bush.GetComponentInParent<TileInfo>().hasBush = false;
            Destroy(bush);
        }
    }
}
