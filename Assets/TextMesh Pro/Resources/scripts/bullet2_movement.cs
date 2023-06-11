
using UnityEngine;
using UnityEngine.UI;

public class bullet2_movement : MonoBehaviour
{
    public bool sniper = false;
    public bool bullet_fire = false;
    public Transform bullet2;
    private Vector3 pos;
    public Transform hero;
    float bullet_velocity_sniper = 12f;
    public Transform bullet1;
    private bool tnt_shooting = false;
    public static int score_text = 0;
    public Text score_text_display;
    public Transform tnt;
    public GameObject pistol_selection;
    public GameObject tnt_selection;
    public GameObject sniper_selection;




    public void OnTriggerEnter2D(Collider2D col)

    {
        if (col.gameObject.tag == "alien_minor")
        {
            bullet_fire = false;
            hit_is_true();

        }

    }
    private void Start()
    {
        score_text = 0;
    }





    // Update is called once per frame
    void FixedUpdate()
    {
        if (sniper == true && tnt_shooting == false)
        {
            bullet2.GetComponent<Renderer>().enabled = false;
            bullet1.GetComponent<Renderer>().enabled = false;
            bullet2.GetComponent<CapsuleCollider2D>().enabled = false;
            bullet1.GetComponent<CapsuleCollider2D>().enabled = false;
            tnt.GetComponent<BoxCollider2D>().enabled = false;
            pistol_selection.SetActive(false);
            tnt_selection.SetActive(false);
            sniper_selection.SetActive(true);



            if (bullet_fire == false)
            {
                pos.x = hero.transform.position.x;
                pos.z = 0;
                pos.y = hero.transform.position.y;
                bullet2.transform.position = pos;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                bullet_fire = true;
            }

            if (bullet_fire == true)
            {
                bullet2.GetComponent<CapsuleCollider2D>().enabled = true;
                bullet2.GetComponent<Renderer>().enabled = true;
                pos.y = pos.y + bullet_velocity_sniper*Time.fixedDeltaTime;
                bullet2.transform.position = pos;

            }
            if (bullet2.transform.position.y >= 5)
            {
                bullet_fire = false;
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
        if (sniper == false)
        {
            bullet2.GetComponent<CapsuleCollider2D>().enabled = false;

        }

        
    }
    public void button_shoot()
    {
        if (sniper == true && tnt_shooting == false)
        {
            bullet_fire = true;
        }
    }
    public void sniper_true()
    {   if (shop_script.sniper_purchased == true) 
        {
            sniper = true;
            
        }
        else if (shop_script.sniper_purchased == false)
        {
            
            sniper = false;

        }

    }
    public void sniper_false()
    {
        sniper = false;
    }
    public void tnt_shoot()
    {
        if (tntmovemt.tnt_count >= 1)
        {
            tnt_shooting = true;
        }
        else if (tntmovemt.tnt_count == 0)
        {
            tnt_shooting = false;
        }

    }
    public void tnt_notshoot()
    {
        tnt_shooting = false;
    }
    public void hit_is_true()
    {
        
        score_text += 1;
        score_text_display.text = score_text.ToString();
    }
}
