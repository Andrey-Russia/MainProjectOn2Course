using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishZone : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CompleteGame();
        }
    }

    private void CompleteGame()
    {
        ResetGameProgress();
        SceneManager.LoadScene("MainMenu");
    }

    private void ResetGameProgress()
    {
        string saveFilePath = Path.Combine(Application.persistentDataPath, "game_save.json");

        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
        }
    }
}