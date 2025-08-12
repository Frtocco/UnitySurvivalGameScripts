using Unity.VisualScripting;
using UnityEngine;

public class PickableObject : InteractableObject
{
    public override void OnInteract()
    {
        if (!InventorySystem.Instance.getIsFull())
        {
            Debug.Log("Picked up: " + ItemName);
            InventorySystem.Instance.AddToInventory(ItemName);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Inventory is full");
        }
    }
}