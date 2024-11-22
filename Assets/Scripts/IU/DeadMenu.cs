using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DeadMenu : MonoBehaviour
{
    [SerializeField] private String sceneToRetry;
    [SerializeField] private GameObject background;
    [SerializeField] private TextMeshProUGUI textDead;
    [SerializeField] private GameObject buttonRetry;
    [SerializeField] private GameObject buttonExit;

    void Start()
    {
        Time.timeScale = 0; // Pausa el juego
        StartCoroutine(FadeInBackground());
    }

    private IEnumerator FadeInBackground()
    {
        UnityEngine.UI.Image bgImage = background.GetComponent<UnityEngine.UI.Image>();
        Color color = bgImage.color;
        float elapsedTime = 0f;
        while (elapsedTime < 2f)
        {
            color.a = Mathf.Lerp(0, 1, elapsedTime / 1f);
            bgImage.color = color;
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }
        color.a = 1;
        bgImage.color = color;
        StartCoroutine(FadeInText(textDead, 3f));
    }

    private IEnumerator FadeInText(TextMeshProUGUI text, float duration)
    {
        Color color = text.color;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            color.a = Mathf.Lerp(0, 1, elapsedTime / duration);
            text.color = color;
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }
        color.a = 1;
        text.color = color;
        buttonRetry.SetActive(true);
        buttonExit.SetActive(true);
        StartCoroutine(FadeInButtons(2f));
    }

    private IEnumerator FadeInButtons(float duration)
    {
        TextMeshProUGUI retryText = buttonRetry.GetComponentInChildren<TextMeshProUGUI>();
        TextMeshProUGUI exitText = buttonExit.GetComponentInChildren<TextMeshProUGUI>();
        Color retryColor = retryText.color;
        Color exitColor = exitText.color;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            retryColor.a = Mathf.Lerp(0, 1, elapsedTime / duration);
            exitColor.a = Mathf.Lerp(0, 1, elapsedTime / duration);
            retryText.color = retryColor;
            exitText.color = exitColor;
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }
        retryColor.a = 1;
        exitColor.a = 1;
        retryText.color = retryColor;
        exitText.color = exitColor;
    }

    public void Retry()
    {
        Time.timeScale = 1; // Reanuda el juego
        // Elimina de la memoria la escena actual y la vuelve a cargar
        SceneManager.LoadScene(sceneToRetry);
    }

    public void ExitToGameMenu()
    {
        Time.timeScale = 1; // Reanuda el juego
        SceneManager.LoadScene("GameMenu");
    }
}
