using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Survival.Assets.Scripts.Models;

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
    TMP_Text StoneAxeReq1, StoneAxeReq2;

    bool isOpen;

    //Blueprints
    Tools stoneAxe = new StoneAxe();

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

        StoneAxeReq1 = toolsScreenUI.transform.Find("StoneAxe").transform.Find("req1").GetComponent<TMP_Text>();
        StoneAxeReq2 = toolsScreenUI.transform.Find("StoneAxe").transform.Find("req2").GetComponent<TMP_Text>();
        craftStoneAxeBTN = toolsScreenUI.transform.Find("StoneAxe").transform.Find("CraftButton").GetComponent<Button>();
        craftStoneAxeBTN.onClick.AddListener(delegate { CraftAnyItem(stoneAxe); });

    }



    public void CraftAnyItem(Tools item)
    {

        foreach (CraftRequirement requirement in item.getRequirements())
        {
            InventorySystem.Instance.RemoveItemFromInventory(requirement.getName(), requirement.getAmount());
        }

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
    
    void Update()
    {
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
