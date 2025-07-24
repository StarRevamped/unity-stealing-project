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
    /*
        public void OnTriggerEnter(Collider other)
        {
            if (item.GetComponent<Rigidbody>().isKinematic && storable)
            {
                InventorySystem inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySystem>();
                    if (100 >= (inventory.GetHaulWeight() + weight))
                    {
                        inventory.AddToList(item);
                        inventory.SetHaulWeight(inventory.GetHaulWeight() + price);
                        inventory.SetHaulPrice(inventory.GetHaulPrice() + price);
                        Destroy(item);
                        inventory.SetJustAddedToInv(true);
                    }
            }
        }
    */
    public Product()
    {
        item = GameObject.FindGameObjectWithTag("sellingProduct");
        productName = "idk";
        container = "shelf";
        storable = true;
        price = 1;
        weight = 1;
    }
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
