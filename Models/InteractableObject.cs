using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string ItemName;

    public string GetItemName()
    {
        return ItemName;
    }

    public virtual void OnInteract()
    {
        Debug.Log("Interacted with: " + ItemName);
    }
    
}
