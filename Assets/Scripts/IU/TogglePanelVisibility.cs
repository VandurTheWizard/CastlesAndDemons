using UnityEngine;

public class TogglePanelVisibility : MonoBehaviour
{
    public GameObject panel;

    // Inicializa el estado del panel (visible o no)
    private bool isPanelVisible = true;

    public void TogglePanel()
    {
        // Cambia la visibilidad del panel
        isPanelVisible = !isPanelVisible;
        panel.SetActive(isPanelVisible);
    }
}
