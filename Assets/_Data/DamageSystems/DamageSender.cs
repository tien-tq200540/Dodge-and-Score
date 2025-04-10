using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageSender : TienMonoBehaviour
{
    [SerializeField] protected int damage = 1;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        this.SendDamage(other);
    }

    protected virtual void SendDamage(Collider2D other)
    {
        if (other == null) return;
        DamageReceiver damageReceiver = other.GetComponent<DamageReceiver>();
        if (damageReceiver == null) return;
        damageReceiver.Deduct(this.damage);
    }
}
