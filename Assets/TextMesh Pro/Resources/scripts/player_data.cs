using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public bool sniper_purchased;
    public int bomb;
    public int coins;
    public float high_score;

    public PlayerData (shop_script shop)
    {
        sniper_purchased = shop_script.sniper_purchased;
        
        coins = shop_script.coins;

    }
    public PlayerData(tntmovemt bombs)
    {
        bomb = tntmovemt.tnt_count;
    }

    
}
