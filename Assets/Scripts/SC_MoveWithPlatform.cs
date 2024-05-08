using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MoveWithPlatform : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            collision.transform.SetParent(transform);
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.transform.SetParent(null);
    }
}
