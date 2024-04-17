using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_GameManager : MonoBehaviour
{
    private PlatformController platformController;
    public SC_MovingPlatform scMovingPlatform;
    public SC_FadePlatform scFadePlatform;

    void Start()
    {
        platformController = new PlatformController();
        platformController.ActivatePlatform(scMovingPlatform);
        platformController.ActivatePlatform(scFadePlatform);
    }

}
