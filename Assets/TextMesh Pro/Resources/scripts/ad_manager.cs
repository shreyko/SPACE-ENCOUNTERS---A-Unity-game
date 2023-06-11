using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class ad_manager : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        Advertisement.Initialize("3756657", true);
        while (!Advertisement.IsReady())
            yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
