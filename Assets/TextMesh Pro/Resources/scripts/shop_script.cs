using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class shop_script : MonoBehaviour,IUnityAdsListener
{
    public GameObject options_menu;
    public GameObject main_menu;
    public GameObject shop;
    public static int coins = 100000;
    public Text coins_display;
    public static bool sniper_purchased = false;
    public int price_sniper = 10000;
    public int price_bomb = 500;
    public static bool bomb_purchased = false;
    public bool charity_bool = false;
    public int price_charity = 20;
    string placement = "rewardedVideo";
    public Text ad_result;
    public GameObject donation_status;
    // Start is called before the first frame update
   private void Start()
    {
        donation_status.SetActive(false);
    }

    public void back()
    {
        options_menu.SetActive(false);
        main_menu.SetActive(true);
        shop.SetActive(false);
    }
    public void purchase_sniper()
    {
        if (coins >= price_sniper)
        {
            sniper_purchased = true;
            coins = coins - price_sniper;
            
        }

    }
    public void purchase_bomb()
    {
        if (coins >= price_bomb)
        {
            bomb_purchased = true;
            coins = coins - price_bomb;
            tntmovemt.tnt_count = tntmovemt.tnt_count + 3;
        }
    }
    public void charity()
    {
        charity_bool = true;
        

    }
    private void Update()
    {
        coins_display.text = coins.ToString();
        if (charity_bool == true)
        {
            StartCoroutine(charitable());
            charity_bool = false;
        }
       
    }
    public IEnumerator charitable()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize("3756657", true);
        while (!Advertisement.IsReady(placement))
            yield return null;
        Advertisement.Show(placement);
        coins = coins - price_charity;
        charity_bool = false;




    }

    public void OnUnityAdsReady(string placementId)
    {
        
    }

    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        shop.SetActive(false);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        shop.SetActive(true);
        donation_status.SetActive(true);
        if (showResult == ShowResult.Finished)
        {
            ad_result.text = "Donation Successful, THANK YOU";
            
        }
        else if (showResult == ShowResult.Failed)
        {
            ad_result.text = "Donation unsuccessful, Please Try Again Later";
        }
    }
}
