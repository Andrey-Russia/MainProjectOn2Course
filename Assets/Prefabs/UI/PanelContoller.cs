using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    public void OpenPanel()
    {
        SetPanelState(true);
    }

    public void ClosePanel()
    {
        SetPanelState(false);
    }

    private void SetPanelState(bool isActive)
    {
        if (panel == null) return;
        panel.SetActive(isActive);
    }
}