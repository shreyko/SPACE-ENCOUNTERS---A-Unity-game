
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Transform hero;
    public bool bullet_fire = false;
    public Transform bullet1;
    private Vector3 pos;
    float bullet_vel = 15f;
    public bool sniper = false;

    public Transform bullet2;
    private bool tnt_shooting = false;
    public Transform tnt;
    public GameObject pistol_selection;
    public GameObject tnt_selection;
    public GameObject sniper_selection;


    void OnTriggerEnter2D(Collider2D col)

    {
        if (col.gameObject.tag == "alien_minor")
        {
            bullet_fire = false;
            bullet2.GetComponent<bullet2_movement>().hit_is_true();


        }

    }









    // Update is called once per frame
    void FixedUpdate()
    {
        if (sniper == false && tnt_shooting == false)
        {
            bullet1.GetComponent<Renderer>().enabled = false;
            bullet2.GetComponent<Renderer>().enabled = false;
            bullet1.GetComponent<CapsuleCollider2D>().enabled = false;
            bullet2.GetComponent <CapsuleCollider2D>().enabled = false;
            tnt.GetComponent<BoxCollider2D>().enabled = false;
            pistol_selection.SetActive(true);
            tnt_selection.SetActive(false);
            sniper_selection.SetActive(false);
            if (bullet_fire == false)
            {
                
                pos.x = hero.transform.position.x;
                pos.z = 0;
                pos.y = hero.transform.position.y;
                bullet1.transform.position = pos;

            }
            if (Input.GetKey(KeyCode.Space))
            {
                bullet_fire = true;
            }

            if (bullet_fire == true)
            {
                bullet1.GetComponent<CapsuleCollider2D>().enabled = true;
                bullet1.GetComponent<Renderer>().enabled = true;

                pos.y = pos.y + bullet_vel * Time.fixedDeltaTime;
                bullet1.transform.position = pos;

            }
            if (bullet1.transform.position.y >= 5)
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

        if (sniper == true)
        {
            bullet1.GetComponent<Renderer>().enabled = false;
            bullet1.GetComponent<CapsuleCollider2D>().enabled = false;






        }

    }
    public void button_shoot()
    {
        if (sniper == false && tnt_shooting == false)
        {
            bullet_fire = true;
        }
    }
    public void sniper_true()
    {
        if (shop_script.sniper_purchased == true)
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
    {if (tntmovemt.tnt_count >= 1)
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
}


