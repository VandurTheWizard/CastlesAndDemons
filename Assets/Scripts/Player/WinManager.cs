using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    public int hordeNumber = 0;
    public bool ordeFinished = false;
    public int enemyNumber = 0;


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
            if(enemyNumber == 0){
                GetComponent<Canvas>().enabled = true;
            }
        }
    }

    public void EnemySpawn(){
        enemyNumber ++;
    }

    public void EnemyDefeated(){
        enemyNumber --;
        if(enemyNumber == 0 && ordeFinished){
            GetComponent<Canvas>().enabled = true;
        }
    }

    public void ReturnToGameMenu(){
        // Cargar la escena del menú principal
        SceneManager.LoadScene("GameMenu");
    }

    
}
