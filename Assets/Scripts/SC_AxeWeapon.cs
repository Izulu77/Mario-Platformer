using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_AxeWeapon : MonoBehaviour, IWeaponReload
{
    public GameObject _axeBall;
    private bool _loaded = false;

    public void Shoot()
    {
        if (_loaded && _axeBall != null)
        {
            GameObject axe = Instantiate(_axeBall, transform.position, new Quaternion());
            SC_Axe scAxe = axe.GetComponent<SC_Axe>();
            if (scAxe != null)
            {
                _loaded = false;
                float direction = 1;
                if (transform.parent != null)
                    direction = transform.parent.localScale.x;
                scAxe.Shoot(direction);
            }
        }
    }
    public void Reload()
    {
        Debug.Log("Axe Was Loaded!");
        _loaded = true;
    }

}
