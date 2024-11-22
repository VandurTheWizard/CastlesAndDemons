using UnityEngine;

public class ChildCollider : MonoBehaviour
{
    public AttackTower parentTower;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            parentTower.OnEnemyEnter(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            parentTower.OnEnemyExit(other.gameObject);
        }
    }
}
