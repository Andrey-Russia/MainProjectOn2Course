using UnityEngine;

public class ShootingProjectile : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform gunMuzzlePoint;
    [SerializeField] private float fireRate = 0.25f;

    private float nextFireTime;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, gunMuzzlePoint.position, gunMuzzlePoint.rotation);
    }
}