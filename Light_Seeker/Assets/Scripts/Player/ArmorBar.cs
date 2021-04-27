using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorBar : MonoBehaviour
{

public Slider slider;
public Gradient gradient;
public Image fill;


    public void SetMaxArmor(int armor){
        slider.maxValue = armor;
        slider.value = armor;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetArmor(double armor){
        slider.value = (int) armor;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
