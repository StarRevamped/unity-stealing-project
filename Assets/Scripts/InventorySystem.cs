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
    private List<GameObject> itemsHeld = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemsHeld.Clear();
        haulWeight = 0;
        haulPrice = 0;
        justAddedToInv = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
        justAddedToInv = false;
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            foreach (GameObject item in itemsHeld)
            {
                Instantiate(item, player.transform.position, player.transform.rotation);
                itemsHeld.Remove(item);
            }
        }
    }

    public void AddToList(GameObject other)
    {
        itemsHeld.Add(other);
    }

/*
    public void OnTriggerEnter(Collider other)
    {
        Product item = other.gameObject.GetComponent<Product>();
        Rigidbody rb = item.GetComponent<Rigidbody>();
        bool isKinematic = rb.isKinematic;
        if (item.gameObject.tag == "sellingProduct" && item.IsStorable())
        {
            if (100 >= (haulWeight + item.GetWeight()))
            {
                //itemsHeld.Add(item);
                haulWeight += item.GetWeight();
                haulPrice += item.GetPrice();
                Destroy(item);
                justAddedToInv = true;
            }
            else
            {
                GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), "You can't hold that much! Hit the gym.");
            }
        }
        else
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), "You have to hold that.");
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
