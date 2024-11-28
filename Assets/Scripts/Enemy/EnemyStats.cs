using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private int health = 3;
    [SerializeField] private int damage = 1;
    [SerializeField] private float porcentDrop = 0.05f;
    [SerializeField] private GameObject drop;
    [SerializeField] private float expForPlayer;
    private bool isDead = false;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0 && !isDead)
        {
            isDead = true;
            if (Random.value <= porcentDrop)
            {
                Instantiate(drop, transform.position, transform.rotation);
            }
            FindFirstObjectByType<WinManager>().EnemyDefeated();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().Exp(expForPlayer);
            Destroy(gameObject);
        }
    }

    public int GetDamage()
    {
        return damage;
    }

    
}
