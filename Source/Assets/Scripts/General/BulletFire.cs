using UnityEngine;

public class BulletFire : MonoBehaviour
{
    public static BulletFire fire { get; private set; }

    public int bulletAmont;
    public float timeInterval;
    public float startAngle;
    public float endAngle;

    public GameObject bulletPool;
    public Transform player;
    public Transform triggerPointBotLeft;
    public Transform triggerPointTopRight;
    public bool checkPosition;
    public bool stopFire;

    private void Awake()
    {
        fire = this;
    }

    void Start()
    {
        InvokeRepeating("Fire", 0f, timeInterval);
    }

    public void StopFire()
    {
        stopFire = true;
    }    

    private bool CheckPosition ()
    {
        bool inRange = player.position.x > triggerPointBotLeft.position.x 
                    && player.position.x < triggerPointTopRight.position.x
                    && player.position.y > triggerPointBotLeft.position.y 
                    && player.position.y < triggerPointTopRight.position.y;

        if (stopFire) inRange = false;
        return inRange;
    }

    private void Fire()
    {
        bool inPlace = true;

        if (checkPosition) inPlace = CheckPosition();

        if (inPlace)
        {
            float angleStep = (endAngle - startAngle) / bulletAmont;
            float angle = startAngle;

            for (int i = 0; i < bulletAmont + 1; i++)
            {
                float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                bulletPool = BulletPool.bulletPoolInstance.GetBullet();
                bulletPool.transform.position = transform.position;
                bulletPool.transform.rotation = transform.rotation;
                bulletPool.SetActive(true);
                bulletPool.GetComponent<Bullet>().SetMoveDirection(bulDir);

                angle += angleStep;
            }
        }
    }
}
