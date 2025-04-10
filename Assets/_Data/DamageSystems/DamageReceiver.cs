using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class DamageReceiver : TienMonoBehaviour
{
    [SerializeField] protected int currentHP = 0;
    [SerializeField] protected int maxHP = 1;
    [SerializeField] protected Rigidbody2D _rigidbody2D;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody2D();
        this.InitHP();
    }

    public virtual void Deduct(int damage)
    {
        if (this.IsDead()) return;
        this.currentHP -= damage;
        if (this.IsDead()) OnDead();
        else OnHurt();
    }

    public virtual bool IsDead()
    {
        return this.currentHP <= 0;
    }

    protected abstract void OnDead();
    protected abstract void OnHurt();

    protected virtual void InitHP()
    {
        this.currentHP = this.maxHP;
    }

    protected virtual void LoadRigidbody2D()
    {
        if (this._rigidbody2D != null) return;
        this._rigidbody2D = GetComponent<Rigidbody2D>();
        this._rigidbody2D.gravityScale = 0f;
        Debug.LogWarning($"{transform.name}: LoadRigidbody2D", gameObject);
    }
}
