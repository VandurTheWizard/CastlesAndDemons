using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject LoadMenu;

    void Start()
    {
        OpenMainMenu();
    }

    public void StarNewGame(){
        SceneManager.LoadScene("GameMenu");
    }

    public void OpenMainMenu()
    {
        mainMenu.SetActive(true);
        LoadMenu.SetActive(false);
    }

    public void OpenLoadMenu()
    {
        mainMenu.SetActive(false);
        LoadMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
