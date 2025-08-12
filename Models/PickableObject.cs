using Unity.VisualScripting;
using UnityEngine;
using Survival.Assets.Scripts.Interfaces;

public class PickableObject : InteractableObject, IPickable
{
    public void OnPick()
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

    public override void OnInteract()
    {
        OnPick();
    }

}