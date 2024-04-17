using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ResetPosition : MonoBehaviour
{
    private Vector3 startPositon;
    private void OnEnable()
    {
        SC_Death.OnSpikeCollision += OnResetPosition;
    }
    private void OnDisable()
    {
        SC_Death.OnSpikeCollision -= OnResetPosition;
    }
    void Awake()
    {
        startPositon = transform.position;
    }
    private void OnResetPosition()
    {
        transform.position = startPositon;
    }
}
