/*
Script for spawning items on all shelves/containers.

DO NOT PUT THIS SCRIPT ON ANY SHELF OR REPEATED OBJECT. THIS IS TO BE PUT ON A SINGLE ITEM IN THE WHOLE MAP.

*/
using UnityEngine;
using System;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;

public class RandomShelfSpawn : MonoBehaviour
{
    //rnd is the random number generator. I put it here to stop it from remaking it 3 million times
    System.Random rnd = new();
    public String[] spawnerTags;
    private GameObject[] spawnableObjects;
    private List<List<Product>> allProducts = new List<List<Product>>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //do NOT judge me. We can for loop this when we know how many containers we have. for now just do it the funky way
        allProducts.Add(new List<Product>()); //Shelf
        allProducts.Add(new List<Product>()); //Cashier shelf
        allProducts.Add(new List<Product>()); //Fridge

        spawnableObjects = GameObject.FindGameObjectsWithTag("sellingProduct");
        foreach (GameObject item in spawnableObjects)
        {
            Product temp = item.GetComponent<Product>();
            switch (temp.GetContainer())
            {
                case "shelf":
                    allProducts[0].Add(temp);
                    break;
                case "cashierShelf":
                    allProducts[1].Add(temp);
                    break;
                case "fridge":
                    allProducts[2].Add(temp);
                    break;
                default:
                    UnityEngine.Debug.Log("Error in RandomShelfSpawn.cs | Could not find container for " + temp.GetProductName());
                    break;
            }
        }
        //stop reading my code
        for (var i = 0; i < spawnerTags.Length; i++)
        {
            SpawnItems(spawnerTags[i], allProducts[i]);
        }
        
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void SpawnItems(String spawner, List<Product> productList)
    {
        GameObject[] spawnLocations = GameObject.FindGameObjectsWithTag(spawner);
        UnityEngine.Debug.Log("spawningLocations list has been filled.");
        foreach (GameObject location in spawnLocations)
        {
            int randomNumber = rnd.Next(0, productList.Capacity);
            UnityEngine.Debug.Log(randomNumber);
            Instantiate(productList[randomNumber].GetObject(), location.transform.position, location.transform.rotation);
        }
    }
}
