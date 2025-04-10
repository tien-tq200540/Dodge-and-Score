using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EnemyDamageSender : DamageSender
{
    [SerializeField] protected CircleCollider2D circleCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCircleCollider2D();
    }

    protected virtual void LoadCircleCollider2D()
    {
        if (this.circleCollider != null) return;
        this.circleCollider = GetComponent<CircleCollider2D>();
        this.circleCollider.radius = 0.5f;
        this.circleCollider.isTrigger = true;
        Debug.LogWarning($"{transform.name}: LoadCircleCollider2D", gameObject);
    }
}
