using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public InventoryItem itemData;
    public int quantity = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (InventorySystem.Instance.AddItem(itemData, quantity))
            {
                Destroy(gameObject); // Remove item from world
            }
        }
    }
}
