using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Invincible : MonoBehaviour
{
    private bool isInvincible = false;
    public bool IsInvincible { get => isInvincible; }

    public float powerUpDuration = 5f;


    public void ActivateInvincibility()
    {
       StartCoroutine(ActivateInvincibilityTimer());
       Debug.Log("Finished ActivateInvincibility " + Time.time);
    }

    IEnumerator ActivateInvincibilityTimer()
    {
        isInvincible = true;
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(powerUpDuration);
        GetComponent<SpriteRenderer>().color = Color.white;
        isInvincible = false;
    }
}
