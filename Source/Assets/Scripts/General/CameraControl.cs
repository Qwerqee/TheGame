using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;
    public Transform standpoint;
    public Transform cameraCheck;
    public float minZoom = 5;
    public float maxZoom = 9;
    public float cameraSpeed = 3;

    private bool isFixed;
    private Vector3 position;

    private void Awake()
    {
        if (!player) player = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        if (cameraCheck.position.x < player.position.x) FixCamera();
        else Follow();
    }


    void Follow()
    {
        position = player.position;
        position.z = -10f;
        if (position.x < 0) position.x = 0;
        if (position.y < 0) position.y = 0;
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * cameraSpeed);
        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, minZoom, Time.deltaTime * cameraSpeed);
    }

    void FixCamera()
    {
        position = standpoint.position;
        position.z = -10f;
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * cameraSpeed);
        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, maxZoom, Time.deltaTime * cameraSpeed);
    }
}
