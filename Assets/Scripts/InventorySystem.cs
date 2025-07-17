using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Meta.XR.BuildingBlocks.Editor;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    //need to make sure haulWeight and haulPrice are accessible to other scripts
    public int haulWeight;
    public int haulPrice;
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
        if (Input.GetKey(KeyCode.W))
        {
            foreach (GameObject item in itemsHeld)
            {
                //add spawn in here i just dont know yet
                Instantiate(item, player.transform.position, player.transform.rotation);
                itemsHeld.Remove(item);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "StorableObject")
        {
            //need .getWeight and .getPrice to be made
            itemsHeld.Add(other);
            //haulWeight += other.getWeight();
            //haulPrice += other.getPrice();
        }
    }
}
