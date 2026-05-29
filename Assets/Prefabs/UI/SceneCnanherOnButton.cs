using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCnanherOnButton : MonoBehaviour
{
    [SerializeField] private int _sceneIndexToLoad = 1;

    public void GoToLevel()
    {
        if (_sceneIndexToLoad >= 0 && _sceneIndexToLoad < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(_sceneIndexToLoad);
        }
    }
}
