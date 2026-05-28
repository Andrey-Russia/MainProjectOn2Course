using TMPro;
using UnityEngine;

public class AltarContoller : MonoBehaviour
{
    [SerializeField] private GameObject secretPassage;
    [SerializeField] private ArtifactCollector artifactCollector;
    [SerializeField] private TextMeshProUGUI artifactCounterText;

    private void Start()
    {
        secretPassage.SetActive(false);
    }

    private void Update()
    {
        CheckAltarActivation();
    }

    private void CheckAltarActivation()
    {
        if (artifactCollector.HasAllArtifacts())
        {
            OpenSecretPassage();
        }
    }

    private void OpenSecretPassage()
    {
        secretPassage.SetActive(true);
        artifactCounterText.text = "Открыт тайный проход!";
    }
}
