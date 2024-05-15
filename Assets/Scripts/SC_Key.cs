using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Key : MonoBehaviour
{
    public static event Action OnKeyCollected;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            OnKeyCollected?.Invoke();
            this.gameObject.SetActive(false);
        }
    }
}
