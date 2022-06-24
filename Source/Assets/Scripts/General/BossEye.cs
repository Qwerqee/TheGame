using UnityEngine;

public class BossEye : MonoBehaviour
{
    public Transform target;

    public float speed;

    private bool toMove = true;
    private Vector3 position;
    private Vector3 standatrPos;

    private void Awake()
    {
        standatrPos = transform.position;
    }
    void FixedUpdate()
    {
        if (Mathf.Abs(transform.position.x) - Mathf.Abs(standatrPos.x) > 0.5f || Mathf.Abs(transform.position.y) - Mathf.Abs(standatrPos.y) > 0.5f)
            transform.position = standatrPos;
        else Follow();
    }

    void Follow()
    {
        toMove = position != target.position;
        position = target.position;
        if (toMove) transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed);
    }
}
