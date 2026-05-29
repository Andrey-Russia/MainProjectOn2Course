using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PanelSoundControl : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Button openButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource panelMusic;

    private void Start()
    {
        openButton.onClick.AddListener(OpenPanel);
        closeButton.onClick.AddListener(ClosePanel);
    }

    private void OpenPanel()
    {
        panel.SetActive(true);
        backgroundMusic.Stop();
        panelMusic.Play();
    }

    private void ClosePanel()
    {
        panel.SetActive(false);
        panelMusic.Stop();
        backgroundMusic.Play();
    }
}