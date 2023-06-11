using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien_level_2 : MonoBehaviour
{

    public GameObject allien;
    private Vector3 pos;
    private Vector3 pos1;
    public bool alien_hit = false;
    Random rand = new Random();
    float y_vel = 1.5f;
    float x_vel = 0.01f;
    public Transform bullet1;
    public Transform bullet2;
    public bool sniper = false;
    public Transform hero;
    private Vector3 screenbounds;
    public Transform Cam;
    public GameObject explosion1;
    public float timer = 0f;
    public int health = 5;
    public GameObject health_bar;
    public GameObject life_lost_animation;
    public float life_lost_animation_timer = 0f;
    public GameObject alien_main;
    float dir;

   
    





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
        pos.x = Random.Range((-screenbounds.x + 3), (screenbounds.x - 3));
        life_lost_animation.SetActive(false);
        dir = Random.Range(-10, 10);

    }

    // Update is called once per frame
    void Update()
    {if (bullet2_movement.score_text >= 20 || bullet2_movement.score_text >=50)
        {
            allien.GetComponent<SpriteRenderer>().enabled = true;
            allien.GetComponent<BoxCollider2D>().enabled = true;
            
            if (alien_hit == false)
            {
                explosion1.GetComponent<Renderer>().enabled = false;
                if (allien.transform.position.y > -4)
                {
                    pos.z = 0;

                    pos.y = pos.y - y_vel * Time.deltaTime;
                    if (dir < 0)
                    {
                        if (pos.x <= screenbounds.x && pos.x >= -screenbounds.x)
                        {
                            pos.x = pos.x - x_vel;
                        }
                    }
                    if (dir >= 0)
                    {
                        if (pos.x <= screenbounds.x && pos.x >= -screenbounds.x)
                        {
                            pos.x = pos.x + x_vel;
                        }
                    }

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
                    alien_main.GetComponent<alien_main>().health_decrease();

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
                pos.x = Random.Range((-screenbounds.x + 6), (-screenbounds.x + 9));
                dir = Random.Range(-10, 10);
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
        if (bullet2_movement.score_text < 30)
        {
            allien.GetComponent<SpriteRenderer>().enabled = false;
            allien.GetComponent<BoxCollider2D>().enabled = false;
            explosion1.GetComponent<SpriteRenderer>().enabled = false;
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
        pos.x = Random.Range((-screenbounds.x + 6), (-screenbounds.x + 9));
        pos.z = 0;
        allien.transform.position = pos;
        dir = Random.Range(-10, 10);

    }
}
