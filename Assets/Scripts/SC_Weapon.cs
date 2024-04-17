using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Weapon : MonoBehaviour
{
    public GameObject _fireBall;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl) && _fireBall != null)
        {
            GameObject fireBall = Instantiate(_fireBall,transform.position,new Quaternion());
            SC_FireBall scFireball = fireBall.GetComponent<SC_FireBall>();
            if(scFireball != null)
            {
                float direction = 1;
                if(transform.parent != null)
                    direction = transform.parent.localScale.x;
                scFireball.Shoot(direction);
            }
        }
    }
}
