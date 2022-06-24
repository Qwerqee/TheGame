using UnityEngine;

public class FocusOnTarget : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        Vector3 difference = target.transform.position - transform.position;     // таргет на игрока
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; // расчет угла
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
    }
    
}
