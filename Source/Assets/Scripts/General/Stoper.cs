using UnityEngine;

public class Stoper : MonoBehaviour
{
    public Transform player;
    public Transform undoRangeX;

    void Update()
    {
        if (player.position.x > undoRangeX.position.x) Undo();
    }

    public void Undo ()
    {
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.GetComponent<Transform>().position = transform.position;
    }
}
