using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pusemenuscript : MonoBehaviour
{
    public static bool game_paused = false;
    public GameObject pauseMenuUI;
    public GameObject settings_menu_in_game;
    public static bool settings_bool = false;
    public static bool go_back = false;


   





    // Update is called once per frame
    void Update()
    {   
        if (game_paused == true)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else if(game_paused == false)
        {
            pauseMenuUI.SetActive(false);
            go_back = false;
            Time.timeScale = 1f;

        }
        if (settings_bool == true)
        {
            settings_menu_in_game.SetActive(true);
            pauseMenuUI.SetActive(false);
            go_back = false;
            

        }
        else if (go_back == true)
        {
            settings_menu_in_game.SetActive(false);
            pauseMenuUI.SetActive(true);



        }
        

    }
    public void game_pause()
    {
        game_paused = true;
    }
    public void game_resume()
    {
        game_paused = false;
    }
    public void settings()
    {

        settings_bool = true;
    }
    public void goback()
    {
        go_back = true;
        settings_bool = false;
    }
    public void forfeit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        game_paused = false;
    }


}
