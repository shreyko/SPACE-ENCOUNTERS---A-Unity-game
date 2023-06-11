using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionsmenu : MonoBehaviour
{
    public GameObject options_menu;
    public GameObject main_menu;
    private void Start()
    {
        options_menu.SetActive(false);
        main_menu.SetActive(true);
    }
    // Start is called before the first frame update
    public void back()
    {
        options_menu.SetActive(false);
        main_menu.SetActive(true);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}

