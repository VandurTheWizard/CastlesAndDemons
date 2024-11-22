using UnityEngine;
using System.Collections;

public class CollisionEnemy : MonoBehaviour
{
    private bool isAttacking = false;
    [SerializeField] private float attackCooldown = 1f;
    private bool touchingDefendObjetive = false;
    private GameObject defendObjetive;

    void Update()
    {
        if (touchingDefendObjetive && !isAttacking)
        {
            StartCoroutine(HandleCollision(defendObjetive));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            gameObject.GetComponent<EnemyStats>().TakeDamage(1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DefendObjetive") && !isAttacking)
        {
            defendObjetive = collision.gameObject;
            touchingDefendObjetive = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DefendObjetive"))
        {
            touchingDefendObjetive = false;
        }
    }

    private IEnumerator HandleCollision(GameObject target)
    {
        isAttacking = true;
        target.GetComponent<DefendObjetiveManager>().TakeDamage(1);
        yield return new WaitForSeconds(attackCooldown);
        SetVulnerable();
    }

    void SetVulnerable()
    {
        isAttacking = false;
    }

}
