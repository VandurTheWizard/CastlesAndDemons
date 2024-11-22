using UnityEngine;

public class OpenLootBox : MonoBehaviour
{
    private GameObject lootBoxCanvas;

    void Start()
    {
        lootBoxCanvas = transform.GetChild(0).gameObject;
        lootBoxCanvas.SetActive(false);      
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Se activa al presionar la tecla espacio
            ToggleLootBoxMenu();
        }
    }

    public void ToggleLootBoxMenu()
    {
        Debug.Log("Activando o desactivando el menú de la caja de botín");
        bool isActive = lootBoxCanvas.activeSelf;
        lootBoxCanvas.SetActive(!isActive);
        Time.timeScale = isActive ? 1 : 0; // Pausa o reanuda el juego
    }

    public void CloseLootBoxMenu()
    {
        Debug.Log("Cerrando el menú de la caja de botín");
        lootBoxCanvas.SetActive(false);
        Time.timeScale = 1; // Reanuda el juego
    }

    public void OpenLootBoxMenu()
    {
        lootBoxCanvas.SetActive(true);
        Time.timeScale = 0; // Pausa el juego
    }
}
