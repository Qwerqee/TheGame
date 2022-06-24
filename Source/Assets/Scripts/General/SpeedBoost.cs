using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    Rigidbody2D rb;

    public float Boost = 0.3f;
    public float maxSpeed = 30f;
    bool isActive;

    void Update()
    {
        if(isActive) Activate();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Sounds.sound.speedBoost.Play();
        isActive = true;
        rb = collision.gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Sounds.sound.speedBoost.Stop();
        isActive = false;
    }
    void Activate()
    {
        float BoostNeg = -Boost;
        if (rb.velocity.magnitude <= maxSpeed)
        {
            float bst = rb.velocity.x < 0 ? BoostNeg : Boost;
            rb.velocity = new Vector2(rb.velocity.x + bst, rb.velocity.y);
        }
    }
}
