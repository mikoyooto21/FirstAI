using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private CanvasGroup cg;
    [SerializeField] private GameObject gameObject;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(true);
            StartCoroutine(FinishSequence());
        }
    }

    private IEnumerator FinishSequence()
    {
        yield return new WaitForSeconds(2f);

        yield return StartCoroutine(FadeCanvasGroup(cg, cg.alpha, 1f, 1f));
        
        string currentSceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentSceneName);
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float start, float end, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(start, end, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = end;
    }
}
