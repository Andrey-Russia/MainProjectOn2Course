using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private float lifeTime = 3f;


    private Vector3 initialVelocity;
    private float startTime;

    private void Awake()
    {
        startTime = Time.time;
        initialVelocity = transform.forward * bulletSpeed;
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().linearVelocity = initialVelocity;

        if (Time.time - startTime > lifeTime)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemyHealth = other.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
            enemyHealth.TakeDamage(1);

        Destroy(gameObject);
    }
}