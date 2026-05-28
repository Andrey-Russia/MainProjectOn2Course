using System.IO;
using TMPro;
using UnityEngine;

[System.Serializable]
public class ArtifactData
{
    public int collectedArtifactsCount;

    public ArtifactData()
    {
        collectedArtifactsCount = 0;
    }
}

public class ArtifactCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI artifactCounterText;
    [SerializeField] private string saveFileName = "artifacts.json";

    private ArtifactData artifactData;

    private string saveFilePath => Path.Combine(Application.persistentDataPath, saveFileName);

    private void Start()
    {
        LoadArtifactData();
        UpdateArtifactCounterText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetArtifactCollection();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Artifact"))
        {
            CollectArtifact(other.gameObject);
        }
    }

    public void CollectArtifact(GameObject artifact)
    {
        artifactData.collectedArtifactsCount++;
        SaveArtifactData();
        UpdateArtifactCounterText();
        Destroy(artifact);
    }

    private void LoadArtifactData()
    {
        if (File.Exists(saveFilePath))
        {
            string dataAsJson = File.ReadAllText(saveFilePath);
            artifactData = JsonUtility.FromJson<ArtifactData>(dataAsJson);
        }
        else
        {
            artifactData = new ArtifactData();
        }
    }

    private void SaveArtifactData()
    {
        string dataAsJson = JsonUtility.ToJson(artifactData);
        File.WriteAllText(saveFilePath, dataAsJson);
    }

    private void UpdateArtifactCounterText()
    {
        artifactCounterText.text = $"Собрано Артефактов: {artifactData.collectedArtifactsCount}/6";
    }

    public bool HasAllArtifacts()
    {
        return artifactData.collectedArtifactsCount >= 6;
    }

    public void ResetArtifactCollection()
    {
        artifactData.collectedArtifactsCount = 1;
        UpdateArtifactCounterText();
        ClearSaveFile();
    }

    private void ClearSaveFile()
    {
        File.WriteAllText(saveFilePath, "{}");
    }
}