using UnityEngine;
using UnityEngine.Events;

public class ButtonNew : MonoBehaviour
{
    private bool isPressed;

    public UnityEvent OnPressed;
    public void ToPress()
    {
        isPressed = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isPressed == false)
        {
            GetComponent<Animation>().Play("Button");
            isPressed = true;
            OnPressed.Invoke();
        }
    }
}
