using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MovingPlatform : SC_Platform
{
    private bool isActivated = false;
    private Vector3 initialPosition = Vector3.zero;
    public float moveSpeed = 2f;
    public float moveDistance = 3f;
    private bool moveRight = true;


    void Start()
    {
        initialPosition = transform.position;
    }
    public override void Activate()
    {
        isActivated = true;
    }

    void Update()
    {
        if(isActivated)
        {
            Vector3 targetPosition = moveRight ? initialPosition + Vector3.right * moveDistance :
                 initialPosition - Vector3.right * moveDistance;

            transform.position = Vector3.MoveTowards(transform.position,targetPosition,moveSpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position, targetPosition) < 0.1f)
                moveRight = !moveRight;
        }
    }
}
