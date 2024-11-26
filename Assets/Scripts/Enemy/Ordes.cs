using UnityEngine;
using System.Collections;

public class Ordes : MonoBehaviour
{
    [System.Serializable]
    public class Horde
    {
        public Transform target; // Objetivo de los enemigos
        public GameObject[] enemyPrefabs; // Array de prefabs de enemigos
        public float spawnInterval; // Intervalo de tiempo entre spawns
        public float duration; // Duración de la horda en segundos
    }

    private Transform spawnPoint; // Punto de generación de enemigos
    [SerializeField] private Horde[] hordes; // Array de hordas
    private int currentHordeIndex = 0; // Índice de la horda actual

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }
        
        spawnPoint = GetComponent<Transform>();
        StartCoroutine(SpawnHordes());
    }

    private IEnumerator SpawnHordes()
    {
        while (currentHordeIndex < hordes.Length)
        {
            Horde currentHorde = hordes[currentHordeIndex];
            float endTime = Time.time + currentHorde.duration;

            while (Time.time < endTime)
            {
                SpawnEnemy(currentHorde);
                yield return new WaitForSeconds(currentHorde.spawnInterval);
            }

            currentHordeIndex++;
        }
        
        // Si no hay más hordas, se activa el WinManager para indicar que se acabo esta orda
        FindFirstObjectByType<WinManager>().HordeDefeated();

    }

    private void SpawnEnemy(Horde horde)
    {
        if (horde.enemyPrefabs.Length != 0)
        {
            int randomIndex = Random.Range(0, horde.enemyPrefabs.Length);
            GameObject enemyPrefab = horde.enemyPrefabs[randomIndex];
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            MoveEnemy moveEnemy = enemy.GetComponent<MoveEnemy>();
            if (moveEnemy != null)
            {
                moveEnemy.SetTarget(horde.target);
            }
        }else{
            return;
        }
        
    }
}
