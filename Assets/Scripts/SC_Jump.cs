using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Jump : MonoBehaviour
{
    public float jumpSpeed = 100;
    private bool isGrounded = false;

    private Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Jump()
    {
       rigid.velocity = Vector3.zero;
       rigid.AddForce(new Vector2(0, jumpSpeed));
    }
    private void Update()
    {
        isGrounded = transform.IsGrounded(LayerMask.GetMask("Default"));
        
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            Jump();
    }
}
