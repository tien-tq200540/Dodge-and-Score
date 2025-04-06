using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDespawn : DespawnByTime
{
    protected override void DespawnObj()
    {
        EnemySpawner.Instance.Despawn(transform.parent);
    }
}
