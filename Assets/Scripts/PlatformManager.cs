using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    
    public GameObject[] tilePrefabs;

    public Transform playerTransform;
    
    private float spawnZ = -17.0f;
    private float safeZone = 30.0f;
    private float tileLength = 20.0f;
    private float thisPositionX;
    
    private int minTilesOnScreen = 8;
    private int lastPrefabIndex = 0;

    private List<GameObject> activeTiles;

    
	private void Start ()
    {
        activeTiles = new List<GameObject>();

        for (int i=0; i<minTilesOnScreen; i++)
        {
            if (i < 2)
                SpawnTile(0);
            else
                SpawnTile();
        }

	}


    private void FixedUpdate () 
    {
		if (playerTransform.position.z - safeZone > (spawnZ - minTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }


    }
    
    
    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;

        go.transform.SetParent(transform);
        go.transform.position = new Vector3 (-5f,0f,1f * spawnZ);
        
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    
    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;

        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(1, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
    
}
