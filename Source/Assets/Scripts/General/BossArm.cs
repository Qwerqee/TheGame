using UnityEngine;

public class BossArm : MonoBehaviour
{
    public GameObject arm;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) arm.GetComponent<Animation>().Play("BossArm");
    }
}
