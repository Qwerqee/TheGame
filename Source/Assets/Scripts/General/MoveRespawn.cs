using UnityEngine;

public class MoveRespawn : MonoBehaviour
{
    public Transform player;
    public Transform cameraCheck;

    void Update()
    {
        if (cameraCheck.position.x < player.position.x) transform.position = cameraCheck.position;
    }
}
