using UnityEngine;
using UnityEngine.Events;

public class PlateNew : MonoBehaviour
{
    private bool isPressed;

    public UnityEvent OnPress;
    public UnityEvent OnLeave;
    public void ToPress()
    {
        isPressed = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isPressed == false) GetComponent<Animation>().Play("Plate_down");
        isPressed = true;
        OnPress.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isPressed == true) GetComponent<Animation>().Play("Plate_up");
        isPressed = false;
        OnLeave.Invoke();
    }
}
