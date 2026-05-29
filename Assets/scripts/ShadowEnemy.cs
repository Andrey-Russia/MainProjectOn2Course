using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ShadowEnemy : MonoBehaviour
{
    [SerializeField] private Transform playerTarget;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Image darknessPanel;
    [SerializeField] private float detectionRange = 2f;
    [SerializeField] private int shadowDamage = 1; // наносим 1 сердце урона

    private void Start()
    {
        RandomizeStartingPosition();
    }

    private void Update()
    {
        MoveTowardsPlayer();
        AdjustDarknessLevel();
        TryAttack();
    }

    private void RandomizeStartingPosition()
    {
        Vector3 randomPosition = Random.insideUnitSphere * 10f;
        NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, 10f, NavMesh.AllAreas);
        transform.position = hit.position;
    }

    private void MoveTowardsPlayer()
    {
        agent.SetDestination(playerTarget.position);
    }

    private void AdjustDarknessLevel()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTarget.position);
        float darknessIntensity = Mathf.Clamp01(1f - (distanceToPlayer / detectionRange));

        darknessPanel.color = new Color(darknessPanel.color.r, darknessPanel.color.g, darknessPanel.color.b, darknessIntensity);
    }

    private void TryAttack()
    {
        float dist = Vector3.Distance(transform.position, playerTarget.position);

        if (dist <= detectionRange)
        {
            DealDamageToPlayer();
        }
    }

    private void DealDamageToPlayer()
    {
        PlayerHealth playerHealth = playerTarget.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(shadowDamage);
        }
    }

    private void OnDeath()
    {
        FindFirstObjectByType<MobCounter>().IncrementKillCount();
    }

    private void OnDestroy()
    {
        OnDeath();
    }
}