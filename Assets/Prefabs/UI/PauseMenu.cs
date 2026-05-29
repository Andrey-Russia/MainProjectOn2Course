using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private FirstPersonController firstPersonController;

    private bool isPaused = false;

    private void Start()
    {
        SetPauseState(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            SetPauseState(isPaused);
        }
    }

    private void SetPauseState(bool isPaused)
    {
        if (pausePanel != null)
        {
            pausePanel.SetActive(isPaused);
        }

        Time.timeScale = isPaused ? 0f : 1f;
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isPaused;

        if (eventSystem != null)
        {
            eventSystem.enabled = isPaused;
        }

        if (firstPersonController != null)
        {
            firstPersonController.enabled = !isPaused;
        }
    }
}