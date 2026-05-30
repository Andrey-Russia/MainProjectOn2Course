using System.IO;
using UnityEngine;
using TMPro;

[System.Serializable]
public class ArtifactData
{
    public int collectedArtifactsCount;
}

public class ArtifactCollector : MonoBehaviour
{
    [SerializeField] private string saveFileName = "artifacts.json";
    [SerializeField] private TextMeshProUGUI artifactCounterText;

    private string saveFilePath => Path.Combine(Application.persistentDataPath, saveFileName);
    internal ArtifactData artifactData;

    private void Awake()
    {
        LoadArtifactData();
    }

    private void Start()
    {
        UpdateArtifactCounterText();
    }

    public void CollectArtifact(GameObject artifact)
    {
        if (artifact != null && !HasSixArtifacts())
        {
            artifactData.collectedArtifactsCount++;
            SaveArtifactData();
            Destroy(artifact);
            UpdateArtifactCounterText();
        }
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
            artifactData = new ArtifactData { collectedArtifactsCount = 0 };
        }
    }

    private void SaveArtifactData()
    {
        string dataAsJson = JsonUtility.ToJson(artifactData);
        File.WriteAllText(saveFilePath, dataAsJson);
    }

    public bool HasFiveArtifacts()
    {
        return artifactData.collectedArtifactsCount >= 5;
    }

    public bool HasSixArtifacts()
    {
        return artifactData.collectedArtifactsCount >= 6;
    }

    public void ResetArtifactCollection()
    {
        artifactData.collectedArtifactsCount = 1;
        SaveArtifactData();
        UpdateArtifactCounterText();
    }

    private void UpdateArtifactCounterText()
    {
        if (artifactCounterText != null)
        {
            artifactCounterText.text = $"Собрано артефактов: {artifactData.collectedArtifactsCount}/6";
        }
    }
}