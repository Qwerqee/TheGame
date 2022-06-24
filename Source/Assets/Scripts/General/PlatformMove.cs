using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    private bool movingRight;
    private bool movingUp;
    private bool moveVertical;
    private bool moveHorizontal;
    private Quaternion startRotation;
    private Vector3 startPosition;

    public float verticalRange = 0f;
    public float horizontalRange = 0f;
    public float moveSpeed = 0f;

    public bool rotateСlockwise;
    public bool rotateСounterclockwise;
    public bool oneMove;

    public void Activate()
    {
        gameObject.GetComponent<PlatformMove>().enabled = true;
    }
    public void Deactivate()
    {
        gameObject.GetComponent<PlatformMove>().enabled = false;
    }

    private void Awake()
    {
        startPosition = transform.localPosition;
        startRotation = transform.rotation;
        if (verticalRange != 0) moveVertical = true;
        if (horizontalRange != 0) moveHorizontal = true;
    }
    private void FixedUpdate()
    {
        if (moveVertical) MovePlatformVertical(moveSpeed, verticalRange);
        if (moveHorizontal) MovePlatformHorizontal(moveSpeed, horizontalRange);
        if (rotateСlockwise) RotatePlatformСlockwise(moveSpeed);
        if (rotateСounterclockwise) RotatePlatformСounterclockwise(moveSpeed);        
    }
    void MovePlatformHorizontal(float speed, float range)
    {
        if (transform.localPosition.x > range)
        {
            movingRight = false;
            if (oneMove) moveHorizontal = false;
        }
        if (transform.localPosition.x < -range)
        {
            movingRight = true;
            if (oneMove) moveHorizontal = false;
        }

        if (!movingRight) speed = -speed;
        transform.localPosition = new Vector2(transform.localPosition.x + speed, transform.localPosition.y);
    }
    void MovePlatformVertical(float speed, float range)
    {
        if (transform.localPosition.y > range)
        {
            movingUp = false;
            if (oneMove) moveVertical = false;
        }
        if (transform.localPosition.y < -range)
        {
            movingUp = true;
            if (oneMove) moveVertical = false;
        }

        if (!movingUp) speed = -speed;
        transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + speed);
    }

    void RotatePlatformСlockwise (float speed)
    {
        speed = -speed;
        transform.Rotate(new Vector3(0f, 0f, speed * 30));
        if (startRotation == transform.rotation && oneMove) rotateСlockwise = false;
    }
    void RotatePlatformСounterclockwise(float speed)
    {
        transform.Rotate(new Vector3(0f, 0f, speed * 30));
        if (startRotation == transform.rotation && oneMove) rotateСounterclockwise = false;
    }
}
