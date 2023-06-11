using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien_main : MonoBehaviour
{
    public Transform allien;
    private Vector3 pos;
    private Vector3 pos1;
    public bool alien_hit = false;
    Random rand = new Random();
    float y_vel;
    public Transform bullet1;
    public Transform bullet2;
    public bool sniper = false;
    public Transform hero;
    private Vector3 screenbounds;
    public Transform Cam;
    public Transform explosion1;
    public float timer = 0f;
    public static int health = 5;
    public GameObject health_bar;
    public GameObject life_lost_animation;
    public float life_lost_animation_timer = 0f;
    




    void OnTriggerEnter2D(Collider2D col)
    {
        if (sniper == false && col.gameObject.tag == "bullet")
        {

            alien_hit = true;



        }
        if (sniper == true && col.gameObject.tag == "bullet")
        {
            alien_hit = true;



        }


    }
    // Start is called before the first frame update
    void Start()
    {
        pos.y = 4;
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Cam.transform.position.z));
        pos.x = Random.Range((-screenbounds.x + 11), (screenbounds.x - 2));
        life_lost_animation.SetActive(false);
        health = 5;

    }

    // Update is called once per frame
    void Update()
    {
        y_vel = Random.Range(1.5f, 2.3f);
        health_bar.GetComponent<health_bar_script>().health_decrease(health);
        if (alien_hit == false)
        {
            explosion1.GetComponent<Renderer>().enabled = false;
            if (allien.transform.position.y > -4)
            {
                pos.z = 0;
                
                pos.y = pos.y - y_vel * Time.deltaTime;
                allien.transform.position = pos;
                life_lost_animation_timer += Time.fixedDeltaTime;
                if (life_lost_animation_timer >= 0.09f)
                {
                    life_lost_animation.SetActive(false);
                }





            }
            if (allien.transform.position.y <= -4)
            {
                alien_reset();
                health_decrease();
                life_lost_animation.SetActive(true);
                life_lost_animation_timer = 0f;
            }


        }
        else if (alien_hit == true)
        {
            timer += Time.fixedDeltaTime;
            if (timer >= 0.08f)
            {
                alien_hit = false;
                timer = 0f;
            }

            pos.z = 0;
            pos.y = 4;
            pos.x = Random.Range((-screenbounds.x + 11), (screenbounds.x - 2));
            pos1.z = 0;
            pos1.y = allien.transform.position.y;
            pos1.x = allien.transform.position.x;
            explosion1.transform.position = pos1;
            explosion1.GetComponent<Renderer>().enabled = true;



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
    public void sniper_true()
    {
        sniper = true;
    }
    public void sniper_false()
    {
        sniper = false;

    }
    public void alien_reset()
    {
        pos.y = 4;
        pos.x = Random.Range((-screenbounds.x + 11), (screenbounds.x - 2));
        pos.z = 0;
        allien.transform.position = pos;
        
    }
    public void health_decrease()
    {if (health > 0)
        {
            health = health - 1;
        }
        
        health_bar.GetComponent<health_bar_script>().health_decrease(health);
        
    }
}
    
    

