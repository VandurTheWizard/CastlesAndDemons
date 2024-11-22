using UnityEngine;

public class DefendObjetiveManager : MonoBehaviour
{
    [SerializeField] private int health = 100;
    private BarFunction barFunction;
    private SpriteRenderer sprite;

    void Start()
    {
        barFunction = transform.GetChild(0).gameObject.GetComponent<BarFunction>();
        barFunction.UpdateBar(health, 100);
        sprite = GetComponent<SpriteRenderer>();
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        sprite.color = Color.red;
        barFunction.UpdateBar(health, 100);
        Invoke("ResetColor", 0.1f);
        if (health <= 0)
        {
            // Se termina la partida (Menu muerte)
            Debug.Log("Game Over");
            
        }
    }

    private void ResetColor()
    {
        sprite.color = Color.white;
    }
}
