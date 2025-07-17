/*
using System.Collections;
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
        itemsHeld.clear;
        haulWeight = 0;
        haulPrice = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //need to figure out a keybind and its keycode
        if(Input.GetKey(KeyCode.W))
        {
            for (int i = 0; i < itemsHeld.length; i++){
                //add spawn in here i just dont know yet
                itemsHeld.RemoveAt(i);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "StorableObject")
        {
            //need .getWeight and .getPrice to be made
            itemsHeld.add(other);
            //haulWeight += other.getWeight();
            //haulPrice += other.getPrice();
        }
    }
}
*/