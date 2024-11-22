using UnityEngine;
using System.Collections;

public class CollisionPlayer : MonoBehaviour
{
    private PlayerStats playerStats;
    private bool vulnerable = true;
    private float vulnerabilityCooldown = 1f;

    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Orb"))
        {
            Destroy(collision.gameObject);
            playerStats.UpdateMoney(collision.GetComponent<Orb>().Value);
        }
        if (collision.gameObject.CompareTag("Health"))
        {
            Destroy(collision.gameObject);
            playerStats.Heal(collision.GetComponent<Health>().health);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && vulnerable)
        {
            StartCoroutine(HandleCollision());
        }
    }

    private IEnumerator HandleCollision()
    {
        vulnerable = false;
        playerStats.TakeDamage(1);
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(vulnerabilityCooldown);
        SetVulnerable();
    }

    void SetVulnerable()
    {
        vulnerable = true;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
