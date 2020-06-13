using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Slider slider;   

    public void setMaxHealth(int Health)
    {
        slider.maxValue = Health;
        slider.value = Health;
    }

    public void setHealth(int Health)
    {
        slider.value = Health;      
    }
}

