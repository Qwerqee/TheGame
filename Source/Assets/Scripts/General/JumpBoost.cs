using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    public float Boost = 600f;
    public float maxSpeed = 30f;
    public bool isBoosted = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

        rb.AddForce(Vector3.up * Boost);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isBoosted = false;
    }
}
