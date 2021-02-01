using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] fruits;
    public GameObject[] eggs;

    private float min_Z = -8f, max_Z = 8f;
    private float positionX;

    private int lastFruitIndex = 0;
    private int lastEggIndex = 0;
    
    //private Transform playerTransform;

    void Start()
    {
        int randomFruit = Random.Range(3, 6);
        
        for (int i=0; i<randomFruit ; i++)
        {
            CreateFruit(i);
            
        }

        CreateEgg();

    }
    
    private int RandomFruitIndex()
    {
        if (fruits.Length <= 1)
            return 0;

        int randomIndex = lastFruitIndex;

        while (randomIndex == lastFruitIndex)
        {
            randomIndex = Random.Range(0, fruits.Length);
        }

        lastFruitIndex = randomIndex;
        return randomIndex;
    }
    

    private void CreateFruit (float distance)
    {
        GameObject fruit;

        positionX = Random.Range(1.5f * distance, 8.7f);
        Vector3 spawnPosition = new Vector3(positionX, 0.3f, Random.Range(min_Z, max_Z));
        
        fruit = Instantiate(fruits[RandomFruitIndex()], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation) as GameObject;
        fruit.transform.SetParent(transform);
    }



    private void CreateEgg()
    {
        GameObject egg;

        positionX = Random.Range(1f, 8f);
        Vector3 spawnPosition = new Vector3(positionX, 0f, min_Z);
        
        egg = Instantiate(eggs[RandomEggIndex()], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation) as GameObject;
        egg.transform.SetParent(transform);
    }
    
    private int RandomEggIndex()
    {
        if (eggs.Length <= 1)
            return 0;

        int randomIndex = lastEggIndex;

        while (randomIndex == lastEggIndex)
        {
            randomIndex = Random.Range(0, eggs.Length);
        }

        lastEggIndex = randomIndex;
        return randomIndex;
    }
}
