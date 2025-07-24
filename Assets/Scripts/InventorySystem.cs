using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Meta.XR.BuildingBlocks.Editor;
using Oculus.Interaction.Body.Input;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    //need to make sure haulWeight and haulPrice are accessible to other scripts
    private int haulWeight;
    private int haulPrice;
    private bool justAddedToInv;
    private List<Product> itemsHeld = new List<Product>();
    public static InventorySystem Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemsHeld.Clear();
        haulWeight = 0;
        haulPrice = 0;
        justAddedToInv = false;
        itemsHeld.Add(new Product());
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        justAddedToInv = false;
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            foreach (Product item in itemsHeld)
            {
                GameObject obj = item.GetObject();
                if (obj != null)
                {
                    Instantiate(obj, player.transform.position, player.transform.rotation);
                }
                haulWeight -= item.GetWeight();
                haulPrice -= item.GetPrice();
            }
            itemsHeld.Clear();
        }
    }

    public void AddItem(Product item, int quantity = 1)
    {
        if (item.IsStorable())
        {
            itemsHeld.Add(item);
        }
    }
/*
    public void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("Trigger entered");
        Product item = other.gameObject.GetComponent<Product>();
        UnityEngine.Debug.Log("Accepted item");
        Rigidbody rb = item.GetObject().GetComponent<Rigidbody>();
        UnityEngine.Debug.Log("Created rigidbody");
        bool isKinematic = rb.isKinematic;
        if (item.gameObject.CompareTag("sellingProduct") && item.IsStorable())
        {
            UnityEngine.Debug.Log("Triggered by product! Testing if can store");
            if (100 >= (haulWeight + item.GetWeight()))
            {
                UnityEngine.Debug.Log("Trying to store item...");
                itemsHeld.Add(item);
                UnityEngine.Debug.Log(item.GetProductName() + " has been added to list");
                haulWeight += item.GetWeight();
                haulPrice += item.GetPrice();
                UnityEngine.Debug.Log("Trying to destroy item...");
                Destroy(item.GetObject());
                UnityEngine.Debug.Log("Item should have been destroyed.");
                justAddedToInv = true;
                
            }
            else
            {
                Debug.Log("FUCK!");
                //GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), "You can't hold that much! Hit the gym.");
            }
        }
        else
        {
           //GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), "You have to hold that.");
        }
    }
*/

    public int GetHaulWeight()
    {
        return haulWeight;
    }
    public void SetHaulWeight(int value)
    {
        haulWeight += value;
    }
    public int GetHaulPrice()
    {
        return haulPrice;
    }
    public void SetHaulPrice(int value)
    {
        haulPrice += value;
    }
    public bool GetJustAddedToInv()
    {
        return justAddedToInv;
    }
    public void SetJustAddedToInv(bool value)
    {
        justAddedToInv = value;
    }
    
}
