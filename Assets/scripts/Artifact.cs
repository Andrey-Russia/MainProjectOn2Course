using UnityEngine;

public class Artifact : MonoBehaviour
{
    [SerializeField] private float activationRadius = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheckDistanceAndCollect(other.transform);
        }
    }

    private void CheckDistanceAndCollect(Transform playerTransform)
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance <= activationRadius)
        {
            CollectArtifact();
        }
    }

    private void CollectArtifact()
    {
        FindFirstObjectByType<ArtifactCollector>().CollectArtifact(this.gameObject);
    }
}