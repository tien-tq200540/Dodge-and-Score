using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerDamageReceiver : DamageReceiver
{
    [SerializeField] protected BoxCollider2D boxCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBoxCollider2D();
    }

    protected override void OnDead()
    {
        transform.parent.gameObject.SetActive(false);
    }

    protected override void OnHurt()
    {
        Debug.Log("Hurt player");
    }

    protected virtual void LoadBoxCollider2D()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = GetComponent<BoxCollider2D>();
        this.boxCollider.isTrigger = true;
        Debug.LogWarning($"{transform.name}: LoadBoxCollider2D", gameObject);
    }
}
