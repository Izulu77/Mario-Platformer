using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PowerUp : MonoBehaviour
{
    public void CollectPowerUp(IPowerUp powerUp)
    {
        powerUp.ApplyPowerUp(this.gameObject);
    }
}
