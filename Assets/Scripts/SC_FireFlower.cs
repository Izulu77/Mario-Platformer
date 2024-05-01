using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_FireFlower : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("OnCollisionEnter2D " + col.gameObject.name);
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Mario Collision! Fire Flower");
            this.gameObject.SetActive(false);
            col.gameObject.GetComponent<SC_PowerUp>().CollectPowerUp(new FireFlower());
        }
    }
}
