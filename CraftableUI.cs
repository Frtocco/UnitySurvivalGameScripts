using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Survival.Assets.Scripts.Models;

public class CraftableUI : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text nameText;
    public TMP_Text requirementsText;
    public Button craftButton;

    private Craftable craftable;

    // Configuración inicial desde CraftingSystem
    public void Setup(Craftable craftable)
    {
        this.craftable = craftable;

        // Nombre del objeto
        if (nameText != null)
            nameText.text = craftable.getName();

        // Botón de crafteo
        if (craftButton != null)
        {
            craftButton.onClick.RemoveAllListeners();
            craftButton.onClick.AddListener(() => CraftingSystem.Instance.CraftAnyItem(craftable));
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        if (craftable == null) return;

        if (requirementsText != null)
            populateRequirementsText();
    }

    // Function that populates the requirements of each recipe.
    public void populateRequirementsText()
    {
        List<CraftRequirement> requirements = craftable.getRequirements();
        string allReqs = "";

        foreach (var req in requirements)
        {
            allReqs += $"{req.getName()}: {req.getAmount()}\n";
        }

        requirementsText.text = allReqs.TrimEnd('\n');
    }

}
