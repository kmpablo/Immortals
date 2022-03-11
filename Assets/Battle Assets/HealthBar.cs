using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;

    public void setMaxHealth(int maxHealth){
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    public void setHealth(int health){
        healthSlider.value = health;
    }
}
