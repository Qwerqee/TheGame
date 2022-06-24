using UnityEngine;

public class Entity : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 moveVector;

    public bool isGrounded = false;
    public bool isDead = false;

    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Death() { }
}
