using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    private GameObject pauseMenu;

    void Start()
    {
        pauseMenu = transform.GetChild(0).gameObject;
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0; // Pausa el juego
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1; // Reanuda el juego
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1; // Reanuda el juego
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitToGameMenu(){
        Time.timeScale = 1; // Reanuda el juego
        SceneManager.LoadScene("GameMenu");
    }

    public void MinimizeAndPause()
    {
        Screen.fullScreen = false; // Minimiza el juego
        PauseGame(); // Pausa el juego y muestra el menú de pausa
    }

    private void TogglePauseMenu()
    {
        if (pauseMenu.activeSelf)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }
}
