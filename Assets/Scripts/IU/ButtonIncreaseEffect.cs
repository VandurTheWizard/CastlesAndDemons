using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonIncreaseEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    public float scaleFactor = 1.2f; // Factor de escala para el efecto de hover

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = originalScale * scaleFactor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalScale;
    }

    public void ReturnToOriginalScale()
    {
        transform.localScale = originalScale;
    }
}
