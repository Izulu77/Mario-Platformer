using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarInvincible : IPowerUp
{
    public void ApplyPowerUp(GameObject player)
    {
        Debug.Log("Start Star Invincible");
        if(player != null)
        {
            SC_Invincible scInvincible = player.GetComponent<SC_Invincible>();
            if(scInvincible != null)
                scInvincible.ActivateInvincibility();
        }
    }
}
