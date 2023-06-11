using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class alien_1 : MonoBehaviour
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
    public int health = 5;
    public GameObject health_bar;
    public GameObject life_lost_animation;
    public float life_lost_animation_timer = 0f;
    public GameObject alien_main;






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
        pos.x = Random.Range((-screenbounds.x + 2), (-screenbounds.x + 4));
        life_lost_animation.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
        y_vel = Random.Range(1.5f, 2.3f);
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
            pos.x = Random.Range((-screenbounds.x + 2), (-screenbounds.x + 4));
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
        pos.x = Random.Range((-screenbounds.x + 2), (-screenbounds.x + 4));
        pos.z = 0;
        allien.transform.position = pos;
        

    }
  
}
