using UnityEngine;

public class VineEnemy : MonoBehaviour
{
    [SerializeField] private Transform playerTarget;
    [SerializeField] private float growthSpeed = 0.1f;
    [SerializeField] private float bendStrength = 0.5f;

    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private float growthProgress;

    private void Start()
    {
        originalPosition = transform.position;
        targetPosition = playerTarget.position;
    }

    private void Update()
    {
        GrowAndBend();
    }

    private void GrowAndBend()
    {
        growthProgress += Time.deltaTime * growthSpeed;
        growthProgress = Mathf.Clamp01(growthProgress);

        Vector3 position = Vector3.LerpUnclamped(originalPosition, targetPosition, growthProgress);
        Vector3 bendOffset = BendCalculation(position);

        transform.position = position + bendOffset;
    }

    private Vector3 BendCalculation(Vector3 currentPosition)
    {
        Vector3 directionToPlayer = (targetPosition - originalPosition).normalized;
        float bendFactor = Mathf.Sin(growthProgress * Mathf.PI * 2f) * bendStrength;

        return directionToPlayer * bendFactor;
    }
}