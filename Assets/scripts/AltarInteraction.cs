using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AltarInteraction : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hintText;
    [SerializeField] private Image fadeScreen;
    [SerializeField] private ArtifactCollector artifactCollector;
    [SerializeField] private float fadeDuration = 2f;

    private Coroutine fadeCoroutine;
    private bool isActivated = false;

    private void Start()
    {
        hintText.gameObject.SetActive(false);
        fadeScreen.color = new Color(0, 0, 0, 0);
    }

    private void Update()
    {
        if (artifactCollector.HasFiveArtifacts())
        {
            hintText.gameObject.SetActive(true);
            hintText.text = "Подойдите к алтарю и нажмите E для жертвоприношения";
        }
        else
        {
            hintText.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) )
        {
            PerformSacrifice();
        }
    }

     private void PerformSacrifice()
    {
        if (!isActivated)
        {
            isActivated = true;
            StartCoroutine(FadeToBlack());
        }
    }

    private IEnumerator FadeToBlack()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            fadeScreen.color = new Color(0, 0, 0, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        artifactCollector.ResetArtifactCollection();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}