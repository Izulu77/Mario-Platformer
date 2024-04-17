using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Weapon : MonoBehaviour
{
    public SC_FireballWeapon _fireBallWeapon;
    public SC_AxeWeapon _axeBallWeapon;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && _fireBallWeapon != null)
            _fireBallWeapon.Shoot();

        if (Input.GetKeyDown(KeyCode.Z) && _axeBallWeapon != null)
            _axeBallWeapon.Shoot();
    }



}
