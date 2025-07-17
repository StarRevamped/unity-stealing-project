using UnityEngine;
using System;

public class RandomShelfSpawn : MonoBehaviour
{
    private GameObject[] spawnableObjects;
    public GameObject[] spawningLocations;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        System.Random rnd = new();
        spawnableObjects = GameObject.FindGameObjectsWithTag("StorableObject");
        foreach (GameObject location in spawningLocations)
        {
            int randomNumber = rnd.Next(0, spawnableObjects.Length);
            Instantiate(spawnableObjects[randomNumber], location.transform.position, location.transform.rotation);
        }
        Console.WriteLine("FUCK!");
        Console.WriteLine(spawnableObjects.Length);
        Console.WriteLine(spawningLocations.Length);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
