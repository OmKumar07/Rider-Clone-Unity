using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public GameObject[] Tiles;
    public float zSpawn = 0;
    public float TileLength;
    public int numberOfTiles;
    public Transform Player;
    private List<GameObject> ActiveTiles = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }
            else
                SpawnTile(Random.Range(0, Tiles.Length));
        }
    }


    void Update()
    {
        if (Player.transform.position.x-300 > zSpawn - (numberOfTiles * TileLength))
        {
            SpawnTile(Random.Range(0, Tiles.Length));
            DeleteTile();
        }

    }
    public void SpawnTile(int tileIndex)
    {
        GameObject tile = Instantiate(Tiles[tileIndex], transform.right * zSpawn, transform.rotation, transform);
        ActiveTiles.Add(tile);
        zSpawn += TileLength;
    }
    private void DeleteTile()
    {
        Destroy(ActiveTiles[0]);
        ActiveTiles.RemoveAt(0);
    }
}

