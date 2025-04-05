using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    public static string Circle_Enemy = "Enemy_Circle";

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only 1 EnemySpawner allows to exist!");
        else instance = this;
    }
}
