using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private int health = 3;
    [SerializeField] private int damage = 1;
    [SerializeField] private float porcentDrop = 0.5f;
    [SerializeField] private GameObject drop;
    [SerializeField] private float expForPlayer;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (Random.value <= porcentDrop)
            {
                Instantiate(drop, transform.position, transform.rotation);
            }

            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().Exp(expForPlayer);
            Destroy(gameObject);
        }
    }

    
}
