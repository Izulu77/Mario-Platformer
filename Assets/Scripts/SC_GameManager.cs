using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_GameManager : MonoBehaviour
{
    private PlatformController platformController;
    public SC_MovingPlatform scMovingPlatform;
    public SC_FadePlatform scFadePlatform;

    private EnemyCreator enemyCreator;

    void Start()
    {
        platformController = new PlatformController();
        platformController.ActivatePlatform(scMovingPlatform);
        platformController.ActivatePlatform(scFadePlatform);

        enemyCreator = new EnemyCreator();
        enemyCreator.CreateEnemy("Goomba", new Vector3(0, 0, 0));
        enemyCreator.CreateEnemy("KoopaTroopa", new Vector3(2, 0, 0));

    }

}
