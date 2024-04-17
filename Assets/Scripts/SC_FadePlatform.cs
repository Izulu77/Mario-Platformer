using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_FadePlatform : SC_Platform
{
    private bool isActivated = false;
    private float turnTime = 3;
    private float startTime = 0;
    private SpriteRenderer curSpriteRenderer;
    private BoxCollider2D curBoxCollider2D;

    void Awake()
    {
        curSpriteRenderer = GetComponent<SpriteRenderer>();
        curBoxCollider2D = GetComponent<BoxCollider2D>();
    }

    public override void Activate()
    {
        isActivated = true;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(isActivated)
        {
            if(Time.time > startTime + turnTime)
            {
                Debug.Log(Time.time);
                curSpriteRenderer.enabled = !curSpriteRenderer.enabled;
                curBoxCollider2D.enabled = !curBoxCollider2D.enabled;
                startTime = Time.time;
            }
        }
    }
}
