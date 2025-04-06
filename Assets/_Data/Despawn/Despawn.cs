using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : TienMonoBehaviour
{
    private void FixedUpdate()
    {
        if (this.CanDespawn()) DespawnObj();
    }

    protected abstract bool CanDespawn();

    protected virtual void DespawnObj()
    {
        Destroy(transform.parent.gameObject);
    }
}
