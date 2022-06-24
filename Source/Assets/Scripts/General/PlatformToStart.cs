using UnityEngine;

public class PlatformToStart : MonoBehaviour
{
    private Quaternion startRotation;
    private Vector3 startPosition;

    public float speed;

    private void Awake()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }
    void Update()
    {
        if (!gameObject.GetComponent<PlatformMove>().enabled) MoveToStart();
    }

    public void MoveToStart ()
    {
        if (transform.position != startPosition) transform.position = Vector3.MoveTowards(transform.position, startPosition, speed);
        if (Quaternion.Angle(transform.rotation, startRotation) > 1) transform.Rotate(new Vector3(0f, 0f, speed * Time.deltaTime * 60));
    }
}
