using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_FireballWeapon : MonoBehaviour, IWeapon
{
    public GameObject _fireBall;
    public void Shoot()
    {
        if(_fireBall != null)
        {
            GameObject fireBall = Instantiate(_fireBall, transform.position, new Quaternion());
            SC_FireBall scFireball = fireBall.GetComponent<SC_FireBall>();
            if (scFireball != null)
            {
                float direction = 1;
                if (transform.parent != null)
                    direction = transform.parent.localScale.x;
                scFireball.Shoot(direction);
            }
        }
    }
}
