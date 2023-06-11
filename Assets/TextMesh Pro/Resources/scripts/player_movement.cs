using UnityEngine;

using UnityEngine.UI;


public class player_movement : MonoBehaviour
{   public Transform hero;
    float x_velocity_right = 8f;
    float x_velocity_left = 8f;
    public bool sniper = false;
    public bool left = false;
    public bool right = false;
    public Button button;
    public Button button1;



    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {if (sniper == true)
        {
            if (hero.transform.position.x < 7.5)
            {
                if (Input.GetKey(KeyCode.RightArrow) || button1.isActiveAndEnabled)
                {

                    transform.Translate(x_velocity_right*Time.deltaTime, 0, 0);
                }
            }

            if (hero.transform.position.x > -7.5)
            {
                if (Input.GetKey(KeyCode.LeftArrow) || button.isActiveAndEnabled)
                {

                    transform.Translate(-x_velocity_left*Time.deltaTime, 0, 0);
                }
            }
        }
        if (sniper == false)
        {
            if (hero.transform.position.x < 5.5)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {

                    transform.Translate(x_velocity_right*Time.deltaTime, 0, 0);
                }
            }

            if (hero.transform.position.x > -5.5)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {

                    transform.Translate(-x_velocity_left*Time.deltaTime, 0, 0);
                }
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            sniper = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            sniper = false;
        }
        







    }
}
