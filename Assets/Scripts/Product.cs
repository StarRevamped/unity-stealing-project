using System;
using UnityEngine;

public class Product : MonoBehaviour
{
    public GameObject item;
    public String productName;
    public String container;
    public bool storable;
    public int price;
    public int weight;

    public String GetProductName()
    {
        return productName;
    }
    public String GetContainer()
    {
        return container;
    }
    public bool IsStorable()
    {
        return storable;
    }
    public int GetPrice()
    {
        return price;
    }
    public int GetWeight()
    {
        return weight;
    }
    public GameObject GetObject()
    {
        return item;
    }
}
