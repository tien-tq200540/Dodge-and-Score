using UnityEngine;

public class PlayerMovement : TienMonoBehaviour
{
    [SerializeField] protected float _speed = 2f;
    [SerializeField] protected float direction;

    protected virtual void FixedUpdate()
    {
        this.Moving();
    }

    protected virtual void Moving()
    {
        direction = Input.GetAxis("Horizontal");
        this.transform.parent.Translate(new Vector3(_speed * direction, 0f, 0f) * Time.fixedDeltaTime);
    }
}
