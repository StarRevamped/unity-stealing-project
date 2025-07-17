using System.Collections;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static int inventoryCount = 0;
    private int weightLoad;
    private ArrayList itemsHeld;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        weightLoad = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
