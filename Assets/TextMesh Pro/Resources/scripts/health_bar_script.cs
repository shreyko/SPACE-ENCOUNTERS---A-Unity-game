using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health_bar_script : MonoBehaviour
{
    public Slider health_bar;
    public void health_decrease(int health)
    {
        health_bar.value = health;
    }
}
