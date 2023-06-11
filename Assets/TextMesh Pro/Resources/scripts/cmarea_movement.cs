
using UnityEngine;

public class cmarea_movement : MonoBehaviour
{
    public bool sniper = false;
    public Transform cam;
    private Vector3 pos;
    private float size = 3.8f;
    




    // Update is called once per frame
    void FixedUpdate()
    {
        if (sniper == false)
        {
            pos.y = -1;
            pos.x = 0;
            pos.z = -10;
            cam.transform.position = pos;
            Camera.main.orthographicSize = size;
        }
        if (sniper == true)
        {
            pos.x = 0;
            pos.y = 0;
            pos.z = -10;
            cam.transform.position = pos;
            Camera.main.orthographicSize = 5;
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
}
