using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Survival.Assets.Scripts.Models;


public class InventorySystem : MonoBehaviour
{

    public static InventorySystem Instance { get; set; }

    public GameObject inventoryScreenUI;

    public List<GameObject> slotList = new List<GameObject>();
    public List<string> itemList = new List<string>();

    private GameObject itemToAdd;
    private GameObject whatSlotToEquip;

    // Item alert pop up
    public GameObject itemAddedAlert;

    private bool isOpen;

    public bool getIsOpen()
    {
        return this.isOpen;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    void Start()
    {
        isOpen = false;

        PopulateSlotList();
    }

    private void PopulateSlotList()
    {
        foreach (Transform child in inventoryScreenUI.transform)
        {
            if (child.CompareTag("Slot"))
            {
                slotList.Add(child.gameObject);
            }
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I) && !isOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("i is pressed");
            inventoryScreenUI.SetActive(true);
            isOpen = true;

        }
        else if (Input.GetKeyDown(KeyCode.I) && isOpen)
        {
            Cursor.lockState = CursorLockMode.Locked;
            inventoryScreenUI.SetActive(false);
            isOpen = false;
        }
    }

    public void AddToInventory(string itemName)
    {
        whatSlotToEquip = FindEmptySlot();

        itemToAdd = Instantiate(Resources.Load<GameObject>(itemName), whatSlotToEquip.transform.position, whatSlotToEquip.transform.rotation);
        itemToAdd.transform.SetParent(whatSlotToEquip.transform);
        itemList.Add(itemName);

        ShowItemAdded(itemName, itemToAdd.GetComponent<Image>().sprite);

    }

    public void RemoveItemFromInventory(string itemName, int amount)
    {
        int counter = amount;

        for (var i = slotList.Count - 1; i >= 0; i--)
        {
            if (slotList[i].transform.childCount > 0)
            {
                if (slotList[i].transform.GetChild(0).name == itemName + "(Clone)" && counter != 0)
                {
                    Destroy(slotList[i].transform.GetChild(0).gameObject);
                    counter--;
                }
            }
        }
        Debug.Log("Deleted " + itemName);
    }

    public void RecalculateList()
    {

        itemList.Clear();

        foreach (GameObject slot in slotList)
        {
            // Function to delete the (Clone) from the string name
            if (slot.transform.childCount > 0)
            {
                string name = slot.transform.GetChild(0).name;
                string remove = "(Clone)";
                string result = name.Replace(remove, "");

                itemList.Add(result);
            }
        }


    }

    private bool CheckIfFull()
    {
        foreach (GameObject slot in slotList)
        {
            if (slot.transform.childCount == 0)
            {
                return false;
            }
        }
        return true;
    }

    private GameObject FindEmptySlot()
    {
        foreach (GameObject slot in slotList)
        {

            if (slot.transform.childCount == 0)
            {
                return slot;
            }
        }
        return new GameObject();
    }

    public bool getIsFull()
    {
        return CheckIfFull();
    }

    private void ShowItemAdded(string itemName, Sprite image)
    {
        TMP_Text itemAddedText = itemAddedAlert.transform.Find("ItemAddedText").GetComponent<TMP_Text>();
        Image itemAddedImage = itemAddedAlert.transform.Find("ItemAddedImage").GetComponent<Image>();

        itemAddedText.text = itemName;
        itemAddedImage.sprite = image;

        CanvasGroup cg = itemAddedAlert.GetComponent<CanvasGroup>();
        if (cg == null)
            cg = itemAddedAlert.AddComponent<CanvasGroup>();

        cg.alpha = 1f;
        itemAddedAlert.SetActive(true);


        StartCoroutine(FadeOutAndDisable(cg, 2f, 1f));

    }
    
    private IEnumerator FadeOutAndDisable(CanvasGroup canvasGroup, float delay, float duration)
    {
        yield return new WaitForSeconds(delay);

        float startAlpha = canvasGroup.alpha;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, time / duration);
            yield return null;
        }

        canvasGroup.alpha = 0f;
        itemAddedAlert.SetActive(false);
    }
}