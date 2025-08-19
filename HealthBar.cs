using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Text healthCounter;

    public GameObject playerState;

    private float currentHealth, maxHealth;

    void Start()
    {
        slider = GetComponent<Slider>();
    }


    void Update()
    {

        currentHealth = playerState.GetComponent<PlayerState>().getCurrentHealth();
        maxHealth = playerState.GetComponent<PlayerState>().getMaxHealth();

        float fillValue = currentHealth / maxHealth;
        slider.value = fillValue;

        healthCounter.text = currentHealth + "/" + maxHealth; 
    }
}
