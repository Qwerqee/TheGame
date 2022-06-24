using System.Collections;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float speed;
    public Transform target;
    public Transform triggerPointBotLeft;
    public Transform triggerPointTopRight;

    void FixedUpdate()
    {
        if (CheckPosition()) ToFollow();
    }
    bool CheckPosition()
    {
        bool inRange = target.position.x > triggerPointBotLeft.position.x
                    && target.position.x < triggerPointTopRight.position.x
                    && target.position.y > triggerPointBotLeft.position.y
                    && target.position.y < triggerPointTopRight.position.y;

        return inRange;
    }

    void ToFollow ()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().AddForce(direction * speed);
    }
    private IEnumerator AnimationDeley()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GetComponent<Animation>().Play("Button");
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(AnimationDeley());
    }
}
