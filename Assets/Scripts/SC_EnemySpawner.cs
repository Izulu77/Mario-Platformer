using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class SC_EnemySpawner : MonoBehaviour
{
    public GameObject enemyObj;
    public Transform spawnPoint;
    public int spawnInterval = 2;

    private CancellationTokenSource cancellationTokenSource;

    private void OnEnable()
    {
        SC_Key.OnKeyCollected += OnKeyCollected;
    }

    private void OnDisable()
    {
        SC_Key.OnKeyCollected -= OnKeyCollected;
    }

    void Start()
    {
        StartSpawning();
    }

    async void StartSpawning()
    {
        try
        {
            cancellationTokenSource = new CancellationTokenSource();
            await SpawnEnemies(cancellationTokenSource.Token);
        }
        catch(Exception e)
        {
            Debug.Log("Spawning Canceled " + e.Message);
        }
    }

    private async Task SpawnEnemies(CancellationToken token)
    {
        while(this != null && !token.IsCancellationRequested)
        {
            Debug.Log("Spawned Enemy " + Time.time);
            await Task.Delay(spawnInterval * 1000);
        }
    }
    private void OnKeyCollected()
    {
        if(cancellationTokenSource != null)
        {
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
            cancellationTokenSource = null;
        }
    }

}
