using UnityEngine;
using UnityEngine.UI;

public class EndGameSequence : MonoBehaviour
{
    [SerializeField] private GameObject beautifulArtifact;
    [SerializeField] private CreditsSequence creditsSequence;
    [SerializeField] private MobCounter mobCounter;

    private void Start()
    {
        beautifulArtifact.SetActive(false);
    }

    private void Update()
    {
        CheckEndConditions();
    }

    private void CheckEndConditions()
    {
        if (mobCounter.EnemiesKilled >= 10)
        {
            ShowBeautifulArtifact();
            StartCreditsSequence();
        }
    }

    private void ShowBeautifulArtifact()
    {
        beautifulArtifact.SetActive(true);
    }

    private void StartCreditsSequence()
    {
        creditsSequence.StartCredits();
    }
}