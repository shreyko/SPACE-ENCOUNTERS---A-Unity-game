using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class tntmovemt : MonoBehaviour
{


    public bool tnt_fire = false;
    float tnt_velocity = 1f;
    private Vector3 pos;
    
    public Transform TNT;
    private bool tnt_select = false;
    public static int tnt_count;
    private float acceleration = 0f;
    public Transform hero;
    private float magnitude = 3f;
    public GameObject pistol_selection;
    public GameObject tnt_selection;
    public GameObject sniper_selection;

   






    // Update is called once per frame
    void FixedUpdate()
    {
        
        
        
            if (tnt_fire == false || tnt_select == false)
            {
                
                TNT.GetComponent<Renderer>().enabled = false;
                TNT.GetComponent<BoxCollider2D>().enabled = false;

                pos.z = 0;
                pos.y = -3;
                TNT.transform.position = pos;
        }
            if (tnt_select == true && tnt_count >= 1)
                
            {
                pistol_selection.SetActive(false);
                tnt_selection.SetActive(true);
                sniper_selection.SetActive(false);
            if (tnt_fire == true)
                {
                    
                    TNT.GetComponent<Renderer>().enabled = true;
                    TNT.GetComponent<BoxCollider2D>().enabled = true;
                
                    pos.y = pos.y + (tnt_velocity + acceleration) * Time.fixedDeltaTime;
                    TNT.transform.position = pos;
                    acceleration += Time.fixedDeltaTime*magnitude;
                }
                if (TNT.transform.position.y >= 5)
                {
                tnt_fire = false;
                
                tnt_count = tnt_count - 1;
                } 
            }
                
        

    }
    public void tnt_true()
    {   
        if ( tnt_count >= 1)
        {
            tnt_select = true;
            tnt_fire = false;

        }
        else if (tnt_count == 0)
        {
            tnt_select = true;
            tnt_fire = false;
        }
        
    }
    public void tnt_shoot()
    {if ( tnt_select==true)
        {
            acceleration = 0;
            tnt_fire = true;
            tnt_select = true;
        }
        
    }
    public void pistol()
    {
        tnt_select = false;
        tnt_fire = false;

    }
    public void sniper()
    {
        tnt_select = false;
        tnt_fire = false;

    }
}



