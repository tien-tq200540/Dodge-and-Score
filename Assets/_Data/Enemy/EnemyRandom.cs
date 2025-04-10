using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandom : TienMonoBehaviour
{
    public int numOfEnemy = 0;
    //public int maxEnemy = 10;
    public float timer = 0f;
    public float timeLimit = 1f;
    public Transform minPos;
    public Transform maxPos;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPosition();
    }

    private void Update()
    {
        this.RandomSpawn();
    }

    protected virtual void RandomSpawn()
    {
        //if (this.numOfEnemy >= this.maxEnemy) return;
        timer += Time.deltaTime;
        if (this.timer < timeLimit) return;
        this.timer = 0f;
        Vector3 spawnPos = GetRandomSpawnPos();
        Transform newEnemy = EnemySpawner.Instance.Spawn(EnemySpawner.Circle_Enemy, spawnPos);
        newEnemy.gameObject.SetActive(true);
        this.numOfEnemy++;
    }

    protected virtual void LoadSpawnPosition()
    {
        this.LoadMinSpawnPos();
        this.LoadMaxSpawnPos();
    }

    protected virtual void LoadMinSpawnPos()
    {
        if (this.minPos != null) return;
        this.minPos = transform.Find("SpawnPos").Find("MinPos");
        Debug.LogWarning($"{transform.name}: LoadMinSpawnPos", gameObject);
    }

    protected virtual void LoadMaxSpawnPos()
    {
        if (this.maxPos != null) return;
        this.maxPos = transform.Find("SpawnPos").Find("MaxPos");
        Debug.LogWarning($"{transform.name}: LoadMaxSpawnPos", gameObject);
    }

    protected virtual Vector3 GetRandomSpawnPos()
    {
        float x = Random.Range(this.minPos.position.x, this.maxPos.position.x);
        float y = Random.Range(this.minPos.position.y, this.maxPos.position.y);
        return new Vector3(x, y, 0f);
    }
}
