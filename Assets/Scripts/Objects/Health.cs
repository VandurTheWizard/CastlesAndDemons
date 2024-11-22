using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int lifeHeal = 2;
    [SerializeField] private float magnetSpeed = -10f; // Velocidad a la que la moneda se moverá hacia el jugador
    [SerializeField] private float magnetSpeedIncreased = 20f; // Velocidad a la que aumentará la velocidad de la moneda
    private Transform player;
    private bool isMagnetActive = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (isMagnetActive && player != null)
        {
            ToPlayer();
        }
    }

    public void ToPlayer(){
        // Mueve la moneda hacia el jugador
            transform.position = Vector3.MoveTowards(transform.position, player.position, magnetSpeed * Time.deltaTime);
            magnetSpeed += magnetSpeedIncreased * Time.deltaTime;
    }

    public int health
    {
        get { return lifeHeal; }
    }

    public bool IsMagnetActive
    {
        get { return isMagnetActive; }
        set { isMagnetActive = value; }
    }
}
