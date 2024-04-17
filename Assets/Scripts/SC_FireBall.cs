using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_FireBall : MonoBehaviour
{
    public float speed = 5f;
    public float destroyTime = 5f;
   
    public void Shoot(float direction)
    {
        transform.localScale = new Vector3(direction, 1,1);
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.AddForce(new Vector3(speed * direction, 0,0));
        StartCoroutine(DestroyObject());
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject);
    }
}
