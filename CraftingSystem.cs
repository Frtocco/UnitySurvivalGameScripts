using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Survival.Assets.Scripts.Models;
using Unity.VisualScripting;
using UnityEditor;

public class CraftingSystem : MonoBehaviour
{

    public GameObject craftingScreenUI;
    public GameObject toolsScreenUI;
    
    public List<string> inventoryItemList = new List<string>();

    //Category Button
    Button toolsBTN;

    //Craft buttons
    Button craftStoneAxeBTN;

    //Requirement text
    TMP_Text StoneAxeRequirements;

    bool isOpen;

    //Blueprints
    Craftable stoneAxe = new StoneAxe();

    // Singleton
    public static CraftingSystem Instance { get; set; }

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

        toolsBTN = craftingScreenUI.transform.Find("Tools").GetComponent<Button>();
        toolsBTN.onClick.AddListener(delegate { OpenToolsCategory(); });

        //Axe GUI
        StoneAxeRequirements = toolsScreenUI.transform.Find("StoneAxe").transform.Find("Requirements").GetComponent<TMP_Text>();
        craftStoneAxeBTN = toolsScreenUI.transform.Find("StoneAxe").transform.Find("CraftButton").GetComponent<Button>();
        craftStoneAxeBTN.onClick.AddListener(delegate { CraftAnyItem(stoneAxe); });
        populateRequirementsText(stoneAxe, StoneAxeRequirements);

    }

    // Function that populates the requirements of each recipe.
    public void populateRequirementsText(Craftable tool, TMP_Text textUI)
    {
        List<CraftRequirement> requirements = tool.getRequirements();
        string allReqs = "";

        foreach (var req in requirements)
        {
            allReqs += $"{req.getName()}: {req.getAmount()}\n";
        }

        textUI.text = allReqs.TrimEnd('\n');
    }

    public void CraftAnyItem(Craftable item)
    {

        foreach (CraftRequirement requirement in item.getRequirements())
        {
            InventorySystem.Instance.RemoveItemFromInventory(requirement.getName(), requirement.getAmount());
        }

        StartCoroutine(DelayedRecalculate());
        StartCoroutine(DelayedAddItem(item));
        
    }

    private IEnumerator DelayedRecalculate()
    {
        yield return null; // espera 1 frame
        InventorySystem.Instance.RecalculateList();
    }

    private IEnumerator DelayedAddItem(Craftable item)
    {
        yield return null; // espera 1 frame
        InventorySystem.Instance.AddToInventory(item.getName());
    }

    public bool getIsOpen()
    {
        return this.isOpen;
    }

    void OpenToolsCategory()
    {

        craftingScreenUI.SetActive(false);
        toolsScreenUI.SetActive(true);
    
    }

    
    // Check in inventory if the items needed to craft the item are met
    private bool CheckIfRequirementsAreMet(Craftable tool)
    {
        List<CraftRequirement> requirements = tool.getRequirements();
        inventoryItemList = InventorySystem.Instance.itemList;

        foreach (CraftRequirement requirement in requirements)
        {
            var amountNeeded = requirement.getAmount();
            foreach (string itemInInventory in inventoryItemList)
            {
                if (itemInInventory == requirement.getName())
                {
                    amountNeeded--;
                }
            }
            if (amountNeeded > 0)
            {
                return false;
            }

        }

        return true;

    }

    void Update()
    {
        if (CheckIfRequirementsAreMet(stoneAxe))
        {
            craftStoneAxeBTN.gameObject.SetActive(true);
            Debug.Log(CheckIfRequirementsAreMet(stoneAxe));
        }
        else
        {
            craftStoneAxeBTN.gameObject.SetActive(false);
            Debug.Log(CheckIfRequirementsAreMet(stoneAxe));
        }

        if (Input.GetKeyDown(KeyCode.C) && !isOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("c is pressed");
            craftingScreenUI.SetActive(true);
            isOpen = true;

        }
        else if (Input.GetKeyDown(KeyCode.C) && isOpen)
        {
            Cursor.lockState = CursorLockMode.Locked;
            craftingScreenUI.SetActive(false);
            toolsScreenUI.SetActive(false);
            isOpen = false;
        }
    }
}
