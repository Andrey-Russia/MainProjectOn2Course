using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class SaveData
{
    public Vector3 playerPosition;
    public List<Vector3> golemPositions;
}

[System.Serializable]
public class ArtifactsSaveData
{
    public int collectedArtifacts;
}

public class GameSaver : MonoBehaviour
{
    [SerializeField] private string saveFileName = "game_save.json";
    [SerializeField] private string artifactsSaveFileName = "artifacts.json";
    [SerializeField] private Button resetButton;

    private string saveFilePath => Path.Combine(Application.persistentDataPath, saveFileName);
    private string artifactsSaveFilePath => Path.Combine(Application.persistentDataPath, artifactsSaveFileName);

    private void Start()
    {
        LoadGame();

        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetGame);
        }
    }

    private void OnApplicationQuit()
    {
        SaveGame();
        SaveArtifacts();
    }

    public void SaveGame()
    {
        SaveData saveData = CreateSaveData();
        string dataAsJson = JsonUtility.ToJson(saveData);
        File.WriteAllText(saveFilePath, dataAsJson);
    }

    public void LoadGame()
    {
        LoadArtifacts();

        if (File.Exists(saveFilePath))
        {
            string dataAsJson = File.ReadAllText(saveFilePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(dataAsJson);
            ApplySaveData(saveData);
        }
    }

    private SaveData CreateSaveData()
    {
        SaveData saveData = new SaveData();
        saveData.playerPosition = GameObject.FindWithTag("Player")?.transform.position ?? Vector3.zero;
        saveData.golemPositions = new List<Vector3>();
        foreach (GameObject golem in GameObject.FindGameObjectsWithTag("Golem"))
        {
            saveData.golemPositions.Add(golem.transform.position);
        }
        return saveData;
    }

    private void ApplySaveData(SaveData saveData)
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = saveData.playerPosition;
        }
        foreach (GameObject golem in GameObject.FindGameObjectsWithTag("Golem"))
        {
            if (saveData.golemPositions.Count > 0)
            {
                golem.transform.position = saveData.golemPositions[0];
                saveData.golemPositions.RemoveAt(0);
            }
        }
    }

    #region Артефакты

    public void SaveArtifacts()
    {
        ArtifactsSaveData artifactsData = CreateArtifactsSaveData();
        string dataAsJson = JsonUtility.ToJson(artifactsData);
        File.WriteAllText(artifactsSaveFilePath, dataAsJson);
    }

    public void LoadArtifacts()
    {
        if (File.Exists(artifactsSaveFilePath))
        {
            string dataAsJson = File.ReadAllText(artifactsSaveFilePath);
            ArtifactsSaveData artifactsData = JsonUtility.FromJson<ArtifactsSaveData>(dataAsJson);
            ApplyArtifactsSaveData(artifactsData);
        }
    }

    private ArtifactsSaveData CreateArtifactsSaveData()
    {
        var collector = FindFirstObjectByType<ArtifactCollector>();
        ArtifactsSaveData data = new ArtifactsSaveData();
        data.collectedArtifacts = collector ? collector.artifactData.collectedArtifactsCount : 0;
        return data;
    }

    private void ApplyArtifactsSaveData(ArtifactsSaveData data)
    {
        var collector = FindFirstObjectByType<ArtifactCollector>();
        if (collector != null)
        {
            collector.artifactData.collectedArtifactsCount = data.collectedArtifacts;
        }
    }
    #endregion

    public void ResetGame()
    {
        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
        }
        if (File.Exists(artifactsSaveFilePath))
        {
            File.Delete(artifactsSaveFilePath);
        }
        SceneManager.LoadScene("MainMenu");
    }
}