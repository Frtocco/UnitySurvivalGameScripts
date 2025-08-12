using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class SelectionManager : MonoBehaviour
{
    public GameObject interaction_Info_UI;
    TMP_Text interaction_text;
    public float maxDistance = 3f;

    private void Start()
    {
        interaction_text = interaction_Info_UI.GetComponent<TMP_Text>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
    
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            var selectionTransform = hit.transform;
            var interactable = selectionTransform.GetComponent<InteractableObject>();
    
            if (interactable != null)
            {
                interaction_text.text = interactable.GetItemName();
                interaction_Info_UI.SetActive(true);
    
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    interactable.OnInteract();
                }
    
                return;
            }
        }
    
        interaction_Info_UI.SetActive(false);
    }

}
