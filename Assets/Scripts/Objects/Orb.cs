using UnityEngine;

public class Orb : MonoBehaviour
{
    [SerializeField] private float value;
    [SerializeField] private float magnetSpeed = -10f; // Velocidad a la que la moneda se moverá hacia el jugador
    [SerializeField] private float magnetSpeedIncreased = 20f; // Velocidad a la que aumentará la velocidad de la moneda
    private Transform player;
    private bool isMagnetActive = false;
    private Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        RandomExp();
        animator = GetComponent<Animator>();
        if(value >= 3f && value < 5f)
        {
            animator.Play("animationOrb2");
        }else{
            animator.Play("animationOrb");
        }
    }

    void Update()
    {
        if (isMagnetActive && player != null)
        {
            ToPlayer();
        }
    }

    private void RandomExp(){
        value = Random.Range(1, 5) * player.GetComponent<PlayerStats>().GetLevel();
    }

    public void ToPlayer(){
        transform.position = Vector3.MoveTowards(transform.position, player.position, magnetSpeed * Time.deltaTime);
        magnetSpeed += magnetSpeedIncreased * Time.deltaTime;
    }

    public float Value
    {
        get { return value; }
    }

    public bool IsMagnetActive
    {
        get { return isMagnetActive; }
        set { isMagnetActive = value; }
    }
}
