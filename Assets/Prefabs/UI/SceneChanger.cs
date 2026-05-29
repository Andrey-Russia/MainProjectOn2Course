using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private int _targetSceneIndex = 0;

    private void Update()
    {
        if (Input.anyKeyDown)
            SceneManager.LoadScene(_targetSceneIndex);
    }
}
