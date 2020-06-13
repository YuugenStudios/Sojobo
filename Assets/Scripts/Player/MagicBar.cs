using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class MagicBar : MonoBehaviour
{
    public Slider slider;

    public void setMaxStrength(int strength)
    {
        slider.maxValue = strength;
        slider.value = strength;
    }

    public void setStrength(int strength)
    {
        slider.value = strength;
    }
}
