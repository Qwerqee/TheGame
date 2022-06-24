using UnityEngine;

public class Player : Entity
{
    public GameObject respawn;

    public float speed = 6f;
    public float jumpForce = 400f;
    private Vector3 luft;

    private void Start()
    {
        Sounds.sound.backgroundMusic.Play();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.R)) isDead = true;
        if (isDead) Death();
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            luft = transform.position;
            luft.y += 0.001f;
            transform.position = luft;
        }
        if (Input.GetAxis("Vertical") > 0 && isGrounded) Jump();
        if (Input.GetAxis("Vertical") < 0 && !isGrounded) Fall();
        if (Input.GetButton("Horizontal")) Walk();
    }

    void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }

    void Jump()
    {
        Sounds.sound.jumpSound.pitch = Random.Range(0.9f, 1.1f);
        Sounds.sound.jumpSound.Play();

        rb.AddForce(Vector2.up * jumpForce);
        isGrounded = false;
    }

    void Fall()
    {
        rb.AddForce(Vector2.down * jumpForce/10);
    }

    protected override void Death()
    {
        Sounds.sound.deathSound.Play();

        rb.velocity = new Vector2(0, 0);
        moveVector = rb.velocity;
        transform.position = respawn.transform.position;

        isDead = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground")
            || collision.gameObject.layer == LayerMask.NameToLayer("SpeedBoost")
            || collision.gameObject.layer == LayerMask.NameToLayer("JumpBoost"))
        {
            isGrounded = true;
            if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
                rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("DeathZone"))
             isDead = true;

        Sounds.sound.fallSound.pitch = Random.Range(0.9f, 1.1f);
        Sounds.sound.fallSound.Play();
    }
}
