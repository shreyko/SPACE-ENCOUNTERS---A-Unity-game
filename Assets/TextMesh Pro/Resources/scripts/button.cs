
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class button : MonoBehaviour

         
{
    public Transform hero;
    
    float x_velocity_left = 0.1f;
    private bool sniper = false;
    private bool button_down;

    public void sniper_true()
    {
        sniper = true;
    }

    public void sniper_false()
    {
        sniper = false;

    }

    public void OnPointerDown()
    {
        button_down = true;
    }

    public void OnPointerUp()
    {
        button_down = false;
    }
    public void movement()
    {
        if (sniper == false)
        {

            if (hero.transform.position.x > -5.5f)
            {

                transform.Translate(-x_velocity_left * Time.deltaTime, 0, 0);



            }


        }
        if (sniper == true)
        {


            if (hero.transform.position.x > -7.5f)
            {

                transform.Translate(-x_velocity_left * Time.deltaTime, 0, 0);



            }


        }
    }
    private void Update()
    {
        if (button_down == true)
        {
            x_velocity_left = 5f;
        }
        else if (button_down == false)
        {
            x_velocity_left = 0f;
        }


    }
    void FixedUpdate()
    {

        movement();

    }

}

