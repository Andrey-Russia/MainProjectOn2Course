using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CreditsSequence : MonoBehaviour
{
    [SerializeField] private Image creditsImage;
    [SerializeField] private float fadeDuration = 5f;

    private Coroutine fadeCoroutine;

    public void StartCredits()
    {
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(FadeInCredits());
    }

    private IEnumerator FadeInCredits()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            creditsImage.color = new Color(1, 1, 1, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}