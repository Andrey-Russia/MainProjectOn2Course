using UnityEngine;
using UnityEngine.AI;

public class GolemController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent navAgent;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private int damagePerAttack = 2; 

    private Transform target;
    private float lastAttackTime;

    public void Initialize(Transform playerTarget)
    {
        target = playerTarget;
    }

    private void Update()
    {
        MoveTowardsTarget();
        TryAttack();
    }

    private void MoveTowardsTarget()
    {
        navAgent.SetDestination(target.position);
        animator.SetBool("IsMoving", true);
    }

    private void TryAttack()
    {
        float dist = Vector3.Distance(transform.position, target.position);

        if (dist <= attackRange && Time.time - lastAttackTime >= attackCooldown)
        {
            StopMovement();
            PlayAttackAnimation();
        }
    }

    private void StopMovement()
    {
        navAgent.isStopped = true;
        animator.SetBool("IsMoving", false);
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger("Attack");
        lastAttackTime = Time.time;
        DealDamageToPlayer();
    }

    private void DealDamageToPlayer()
    {
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damagePerAttack);
        }
    }

    private void OnDestroy()
    {
        FindFirstObjectByType<SequentialGolemActivator>()?.OnGolemDestroyed(gameObject);
    }
}