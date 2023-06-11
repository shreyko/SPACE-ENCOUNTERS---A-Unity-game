
using UnityEngine;

public class button_right : MonoBehaviour
{
    public Transform hero;
    float x_velocity_right = 0.5f;
    
    private bool sniper = false;
    private bool button_down = false;


    // Update is called once per frame
    
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
            
                if (hero.transform.position.x < 5.5f)
                {

                    transform.Translate(x_velocity_right * Time.deltaTime, 0, 0);



                }
            

        }
        if (sniper == true)
        {
            
            
                if (hero.transform.position.x < 7.5f)
                {

                    transform.Translate(x_velocity_right * Time.deltaTime, 0, 0);



                }
            

        }
    }
    private void Update()
    {
        if (button_down == true)
        {
            x_velocity_right = 5f;
        }
        else if (button_down == false)
        {
            x_velocity_right = 0f;
        }

        
    }
    void FixedUpdate()
    {

        movement();

    }

}
