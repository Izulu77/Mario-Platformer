using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_FireballWeapon : MonoBehaviour, IUseableWeapon
{
    public GameObject _fireBall;
    private bool _isEquip = false;

    public void Shoot()
    {
        if(_isEquip && _fireBall != null)
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

    public void Equip()
    {
        _isEquip = true;
    }

    public void UnEquip()
    {
        _isEquip = false;
    }
}
