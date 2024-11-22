using UnityEngine;
using UnityEngine.UI;

public class BarFunction : MonoBehaviour
{
    private Image barImage;

    // Start is called before the first frame update
    void Awake()
    {
        barImage = transform.GetChild(1).GetComponent<Image>();
    }

    public void UpdateBar(float value, float maxValue)
    {
            barImage.fillAmount = value / maxValue;
    }
}
