using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    private int hordeNumber = 0;
    private bool ordeFinished = false;
    private int enemyNumber = 0;


    void Awake()
    {
        GetComponent<Canvas>().enabled = false;
        hordeNumber = GameObject.FindGameObjectsWithTag("Horde").Length;
    }

    public void HordeDefeated()
    {
        hordeNumber--;
        if (hordeNumber == 0)
        {
            ordeFinished = true;
        }
    }

    public void EnemySpawn(){
        enemyNumber ++;
        Debug.Log("Enemies: " + enemyNumber);
    }

    public void EnemyDefeated(){
        enemyNumber --;
        Debug.Log("Enemies: " + enemyNumber);
        if(enemyNumber == 0 && ordeFinished){
            Debug.Log("You win");
            GetComponent<Canvas>().enabled = true;
        }
    }

    public void ReturnToGameMenu(){
        // Cargar la escena del menú principal
        SceneManager.LoadScene("GameMenu");
    }

    
}
