using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    public static PlayerState Instance { get; private set; }

    //Health
    public float currentHealth;
    public float maxHealth;

    // Stamina
    public float currentStamina;
    public float maxStamina;

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
        currentHealth = maxHealth;
    }

    void Update()
    {

    }

    public float getMaxHealth()
    {
        return this.maxHealth;
    }

    public float getCurrentHealth()
    {
        return this.currentHealth;
    }

    public float getMaxStamina()
    {
        return this.maxStamina;
    }

    public float getCurrentStamina()
    {
        return this.currentStamina;
    }
}
