using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandom : TienMonoBehaviour
{
    public int numOfEnemy = 0;
    public int maxEnemy = 10;
    public float timer = 0f;
    public float timeLimit = 5f;

    private void Update()
    {
        this.RandomSpawn();
    }

    protected virtual void RandomSpawn()
    {
        if (this.numOfEnemy >= this.maxEnemy) return;
        timer += Time.deltaTime;
        if (this.timer < timeLimit) return;
        this.timer = 0f;
        Transform newEnemy = EnemySpawner.Instance.Spawn(EnemySpawner.Circle_Enemy, new Vector3(0f, 5f, 0f));
        newEnemy.gameObject.SetActive(true);
        this.numOfEnemy++;
    }
}
