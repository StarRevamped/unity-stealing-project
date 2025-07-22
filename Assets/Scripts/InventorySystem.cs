using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Meta.XR.BuildingBlocks.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    //need to make sure haulWeight and haulPrice are accessible to other scripts
    private int haulWeight = 0;
    private int haulPrice = 0;
    private ArrayList itemsHeld = new ArrayList();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemsHeld.Clear();
        haulWeight = 0;
        haulPrice = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
        //need to figure out a keybind and its keycode
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            foreach (GameObject item in itemsHeld)
            {
                Instantiate(item, player.transform.position, player.transform.rotation);
                itemsHeld.Remove(item);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Product item = other.gameObject.GetComponent<Product>();
        if (other.gameObject.tag == "sellingProduct" && item.IsStorable())
        {
            if (100 >= (haulWeight += item.GetWeight()))
            {
                itemsHeld.Add(item);
                haulWeight += item.GetWeight();
                haulPrice += item.GetPrice();
                Destroy(item);
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

    public int GetHaulWeight()
    {
        return haulWeight;
    }
}
