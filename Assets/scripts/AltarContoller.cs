using UnityEngine;

public class AltarController : MonoBehaviour
{
    [SerializeField] private GameObject secretPassage;
    [SerializeField] private ArtifactCollector artifactCollector;


private void Start()
    {
        secretPassage.SetActive(true);
    }

    private void Update()
    {
        CheckAltarActivation();
    }

    private void CheckAltarActivation()
    {
        if (artifactCollector.HasSixArtifacts())
        {
            OpenSecretPassage();
        }
    }

    private void OpenSecretPassage()
    {
        secretPassage.SetActive(false);
    }
}