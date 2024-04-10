using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Player : MonoBehaviour
{
    private float direction;
    private Vector3 startPositon;
    public float speed = 5;
    public float jumpSpeed = 100;
    private bool isJumping = false;

    private Rigidbody2D rigid;

    private void OnEnable()
    {
        SC_Death.OnSpikeCollision += OnSpikeCollision;
        SC_Floor.OnFloorCollision += OnFloorCollision;
    }

    private void OnDisable()
    {
        SC_Death.OnSpikeCollision -= OnSpikeCollision;
        SC_Floor.OnFloorCollision -= OnFloorCollision;
    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        startPositon = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = Input.GetAxis("Horizontal");
        if (direction != 0 && rigid != null)
        {
            rigid.velocity = new Vector2(direction * speed, rigid.velocity.y);

            if (direction > 0)
                transform.localScale = new Vector3(1, 1, 1);
            else transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void OnSpikeCollision()
    {
        transform.position = startPositon;
    }
    private void OnFloorCollision()
    {
        isJumping = false;
    }

    private void Jump()
    {
        if (isJumping == false)
        {
            rigid.AddForce(new Vector2(0, jumpSpeed));
            isJumping = true;
        }
    }


}
