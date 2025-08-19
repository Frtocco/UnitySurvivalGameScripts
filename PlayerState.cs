using System.Collections;
using System.Collections.Generic;
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
        return maxHealth;
    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }

    public float getMaxStamina()
    {
        return maxStamina;
    }

    public float getCurrentStamina()
    {
        return currentStamina;
    }
}
