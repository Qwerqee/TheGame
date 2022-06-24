using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform player;
    public float bottomPosition = 10f;

    private float startY;
    private void Awake()
    {
        startY = transform.position.y;
    }
    void Update()
    {
        if (transform.position.x < player.position.x && transform.position.y >= bottomPosition)
            transform.position = new Vector2(transform.position.x, transform.position.y - Mathf.Abs(bottomPosition) * Time.deltaTime);
        if (transform.position.x > player.position.x && transform.position.y <= startY) 
            transform.position = new Vector2(transform.position.x, transform.position.y + Mathf.Abs(startY) * Time.deltaTime);
    }
}
