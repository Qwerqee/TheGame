using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed;
    public float stayTime;
    private Vector2 moveDirection;

    private void OnEnable()
    {
        Invoke("Destroy", stayTime);
    }
    
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}
