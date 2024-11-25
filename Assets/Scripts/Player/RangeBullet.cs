using UnityEngine;

public class RangeBullet : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer;
    private bool enemyDetected;

    public bool EnemyDetected
    {
        get { return enemyDetected; }
    }

    void Update()
    {
        RaycastHit2D hit;
        Vector2 forward = transform.TransformDirection(Vector2.right) * 5;

        // Realiza el Raycast en 2D desde la posición actual hacia adelante
        hit = Physics2D.Raycast(transform.position, forward, 10, enemyLayer);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                enemyDetected = true;
            }
            else
            {
                enemyDetected = false;
            }
        }
        else
        {
            enemyDetected = false;
        }

        // Dibuja el Raycast en la escena para que sea visible (línea roja)
        Debug.DrawRay(transform.position, forward, Color.red);
    }
}
