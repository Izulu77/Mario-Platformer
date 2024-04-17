using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Axe : MonoBehaviour
{
    public float xSpeed = 5;
    public float ySpeed = 5;
    public float destroyTime = 5;
    public void Shoot(float direction)
    {
        transform.localScale = new Vector3(direction, 1, 1);
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.AddForce(new Vector3(xSpeed * direction, ySpeed, 0));
        StartCoroutine(DestroyObject());
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject);
    }
}
