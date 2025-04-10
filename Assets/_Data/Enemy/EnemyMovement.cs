using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : TienMonoBehaviour
{
    [SerializeField] protected float _speed = 2f;
    [SerializeField] protected Vector3 direction = Vector3.down;

    protected virtual void FixedUpdate()
    {
        this.Moving();
    }

    protected virtual void Moving()
    {
        this.transform.parent.Translate(direction * this._speed * Time.fixedDeltaTime);
    }
}
