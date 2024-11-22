using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using NavMeshPlus.Components;

public class PlaceTower : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private GameObject shadowPrefab;
    [SerializeField] private float towerCost = 20;
    [SerializeField] private float addCostPerTower = 5;
    [SerializeField] private NavMeshSurface navMeshSurface;
    private GameObject shadowInstance;
    private bool isPlacingTower = false;
    private bool canPlace = true;
    private SpriteRenderer shadowSpriteRenderer;
    private PlayerStats playerStats;
    public TextMeshProUGUI noBuyTower;

    void Start()
    {
        shadowInstance = Instantiate(shadowPrefab);
        shadowInstance.SetActive(false);
        shadowSpriteRenderer = shadowInstance.GetComponent<SpriteRenderer>();
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        noBuyTower.enabled = false;
        
    }

    void Update()
    {
        if (isPlacingTower && playerStats.Money >= towerCost)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;
            
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            worldPosition.z = 0;

            // Cambia el color del SpriteRenderer según si se puede colocar o no
            shadowSpriteRenderer.color = canPlace ? Color.blue : Color.red;
            

            shadowInstance.transform.position = worldPosition;
    
            canPlace = shadowInstance.GetComponent<ControlTrigers>().CanPlace();

            if (Input.GetMouseButtonDown(0) && canPlace)
            {
                // Crea el objeto en la posición del shadow
                Instantiate(towerPrefab, worldPosition, Quaternion.identity);
                // Actualiza el dinero del jugador
                playerStats.UpdateMoney(-towerCost);
                // Aumenta el costo por torre
                towerCost += addCostPerTower;
                UpdateCostTower();
                // Actualiza la zona de navegación de la IA
                navMeshSurface.BuildNavMesh();
                // Desactiva el shadow de la torre
                isPlacingTower = false;
                shadowInstance.SetActive(false);
            }
        }
    }

    public void StartPlacingTower()
    {
        // Si el jugador tiene suficiente dinero, se activa el shadow de la torre
        if(playerStats.Money >= towerCost)
        {
            isPlacingTower = true;
            shadowInstance.SetActive(true);
        }else{
            // Si no tiene suficiente dinero, se activa el texto de "X"
            StartCoroutine(BlinkText(2, 0.2f));
        }
    }

    //Se activa un texto que parpadea
     private IEnumerator BlinkText(int blinkCount, float blinkDuration = 0.5f)
    {
        for (int i = 0; i < blinkCount; i++)
        {
            noBuyTower.enabled = true;
            yield return new WaitForSeconds(blinkDuration);
            noBuyTower.enabled = false;
            yield return new WaitForSeconds(blinkDuration);
        }
    }

    // Los colisionadores actuan de manera que si toca un elemento que no se pueda construir se añade a una lista
    // y si sale de ese elemento se elimina de la lista para evitar que si hay varios elementos y sale de uno de ellos
    // detecte que hay mas y no se pueda construir
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("No se puede colocar la torre aquí");
        if (other.CompareTag("Tower") || other.CompareTag("NoBuildZone"))
        {
            canPlace = false;
            Debug.Log("No se puede colocar la torre aquí");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Se puede colocar la torre aquí");
        if (other.CompareTag("Tower") || other.CompareTag("NoBuildZone"))
        {
            Debug.Log("Se puede colocar la torre aquí");
            canPlace = true;
        }
    }

    // Actualiza el costo de la torre
    private void UpdateCostTower(){
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Cost: " + towerCost;
    }

    // Actualiza la zona de navegación de la IA
    public void SetNavMeshSurface(NavMeshSurface navMeshSurface)
    {
        this.navMeshSurface = navMeshSurface;
    }
}
