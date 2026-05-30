using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCursorManager : MonoBehaviour
{
    private void Start()
    {
        EnableCursor();
    }

    private void EnableCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}