using UnityEngine;
using TMPro;

public class TextFunction : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    [SerializeField] private float fadeDuration = 3f; // Duración del desvanecimiento en segundos
    private float fadeTimer;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        fadeTimer = fadeDuration;
    }

    void Update()
    {
        if (fadeTimer > 0)
        {
            fadeTimer -= Time.deltaTime;
            float alpha = Mathf.Clamp01(fadeTimer / fadeDuration);
            Color color = textMeshPro.color;
            color.a = alpha;
            textMeshPro.color = color;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
