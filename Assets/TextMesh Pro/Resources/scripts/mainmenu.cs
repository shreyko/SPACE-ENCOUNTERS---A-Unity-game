using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public GameObject options_menu;
    public GameObject main_menu;
    public GameObject shop;
    private void Start()
    {
        options_menu.SetActive(false);
        main_menu.SetActive(true);
        shop.SetActive(false);
    }
    public void play_game()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void enter_options()
    {
        options_menu.SetActive(true);
        main_menu.SetActive(false);
        shop.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void enter_shop()
    {
        options_menu.SetActive(false);
        main_menu.SetActive(false);
        shop.SetActive(true);
    }
    
        
    
}
