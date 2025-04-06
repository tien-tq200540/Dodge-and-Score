using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DespawnByTime : Despawn
{
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeLimit = 3f;
    protected override bool CanDespawn()
    {
        timer += Time.fixedDeltaTime;
        if (timer < timeLimit) return false;
        timer = 0f;
        return true;
    }
}
