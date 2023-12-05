using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Paused : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    private bool paused = false;

    public Button resume;

    private void Start()
    {
        resume.onClick.AddListener(OnResume);
    }

    public void OnPause()
    {
        if (!paused)
        {
            StartCoroutine(FadeCanvasGroup(canvasGroup, canvasGroup.alpha, 0.5f, 1f));
            resume.gameObject.SetActive(true);
            canvasGroup.blocksRaycasts = true;
            paused = true;
            Time.timeScale = 0;
        }
        else
        {
            OnResume();
        }
    }

    private void OnResume()
    {
        StartCoroutine(FadeCanvasGroup(canvasGroup, canvasGroup.alpha, 0f, 1f));
        resume.gameObject.SetActive(false);
        canvasGroup.blocksRaycasts = false;
        paused = false;
        Time.timeScale = 1;
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float start, float end, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(start, end, elapsedTime / duration);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }

        canvasGroup.alpha = end;
    }
}
