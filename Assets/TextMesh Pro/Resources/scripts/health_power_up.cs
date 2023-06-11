using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class health_power_up : MonoBehaviour

{
    public GameObject healthpower_up;
    private Vector3 screenbounds;
    private Vector3 pos;
    public Transform Cam;
    public bool power_up_collected = false;
    private float power_up_velocity = 1f;
    public float timer = 0;
    public void OnTriggerEnter2D(Collider2D col)

    {
        if (col.gameObject.tag == "hero")
        {
            power_up_collected = true;

        }

    }



    // Start is called before the first frame update
    void Start()
    {
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Cam.transform.position.z));
        pos.x = Random.Range((-screenbounds.x + 3), (screenbounds.x - 3));
        pos.y = 4;
        healthpower_up.transform.position = pos;
        false_everything();
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        

        if (timer > 8)
        {
            true_everything();
        }
        if (timer <= 8)
        {
            false_everything();
        }





        if (healthpower_up.transform.position.y > -4 && healthpower_up.GetComponent<SpriteRenderer>().enabled == true)
        {
            healthpower_up.SetActive(true);
            pos.y = pos.y - power_up_velocity * Time.fixedDeltaTime;
            pos.z = 0;
            healthpower_up.transform.position = pos;


        }

        if (healthpower_up.transform.position.y <= -4)
        {
            Reset_power_up();



        }
        if (power_up_collected == true)
        {
            alien_main.health = 5;

            Reset_power_up();
        }

    }

    public void Reset_power_up()
    {
        pos.y = 4;
        pos.z = 0;
        pos.x = Random.Range((-screenbounds.x + 3), (screenbounds.x - 3));
        healthpower_up.transform.position = pos;
        timer = 0;
        power_up_collected = false;
        false_everything();


    }
    public void false_everything()
    {
        healthpower_up.GetComponent<SpriteRenderer>().enabled = false;
        healthpower_up.GetComponent<CircleCollider2D>().enabled = false;
        
    }
    public void true_everything()
    {
        healthpower_up.GetComponent<SpriteRenderer>().enabled = true;
        healthpower_up.GetComponent<CircleCollider2D>().enabled = true;

    }
}
