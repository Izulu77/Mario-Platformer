using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator 
{
    public void CreateEnemy(string enemyTypeName,Vector3 position)
    {
        Type type = Type.GetType(enemyTypeName);
        if(type == null)
        {
            Debug.LogError("Invalid Enemy Type!");
            return;
        }

        GameObject enemyObject = new GameObject(enemyTypeName);
        Enemy enemy = enemyObject.AddComponent(type) as Enemy;
        if(enemy == null)
        {
            Debug.LogError("Cant Add component to enemy!");
            return;
        }

        enemyObject.transform.position = position;
        //enemy.Initilize();

        var method = type.GetMethod("Initilize");
        method.Invoke(enemy,null);
    }
}
