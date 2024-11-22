using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonUpEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalPosition;
    public float hoverHeight = 10f;

    void Start()
    {
        originalPosition = transform.position;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.position = originalPosition + new Vector3(0, hoverHeight, 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.position = originalPosition;
    }
}