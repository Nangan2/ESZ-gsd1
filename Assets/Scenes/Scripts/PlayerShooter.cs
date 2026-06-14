using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    private PlayerStats stats;
    private float nextShotTime;



    void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time >= nextShotTime)
            {
                Shoot();

                nextShotTime =
                    Time.time + (1f / stats.attackSpeed);
            }
        }
    }

    void Shoot()
    {
        Vector3 mousePos =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePos.z = 0;

        Vector2 baseDirection =
            (mousePos - firePoint.position).normalized;

        int count = stats.projectileCount;

        float totalSpread =
            (count - 1) * stats.projectileSpread;

        float startAngle =
            -totalSpread / 2f;

        for (int i = 0; i < count; i++)
        {
            float angle =
                startAngle + i * stats.projectileSpread;

            Vector2 shotDirection =
                Quaternion.Euler(0, 0, angle) * baseDirection;

            GameObject bullet =
                Instantiate(
                    bulletPrefab,
                    firePoint.position,
                    Quaternion.identity);

            Bullet bulletScript =
                bullet.GetComponent<Bullet>();

            bulletScript.speed = stats.bulletSpeed;
            bulletScript.damage = stats.damage;
            bulletScript.lifeTime = stats.bulletLifeTime;

            bulletScript.Initialize(shotDirection);
        }
    }
}