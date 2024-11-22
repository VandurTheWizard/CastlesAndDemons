using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTower : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float attackCooldown = 1.0f;
    [SerializeField] private int attackDamage;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int levelTower = 1;
    private float attackRange = 2.5f;

    private List<GameObject> enemiesInRange = new List<GameObject>();
    private GameObject currentTarget;
    private Transform aimTransform; 
    private bool isAttacking = false;

    void Start()
    {
        // Añadir un collider al hijo para detectar enemigos
        var childCollider = transform.GetChild(0).gameObject.AddComponent<ChildCollider>();
        childCollider.parentTower = this;
        // Doy el rango de ataque al collider hijo
        attackRange = childCollider.GetComponent<CircleCollider2D>().radius;

        // Obtengo el transform del hijo que apunta al enemigo
        aimTransform = transform.GetChild(1);
    }

    void Update()
    {
        if (currentTarget != null){
            AimAtTarget(currentTarget);
            if(!isAttacking)
                StartCoroutine(AttackEnemy(currentTarget));
        }
    }

    // Método para apuntar al enemigo objetivo
    private void AimAtTarget(GameObject target)
    {
        Vector3 direction = (target.transform.position - aimTransform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        aimTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    // Método para obtener el objetivo de la torre
    public void OnEnemyEnter(GameObject enemy)
    {
        enemiesInRange.Add(enemy);
        enemy.GetComponent<SpriteRenderer>().color = Color.red;

        if (currentTarget == null)
        {
            currentTarget = enemy;
        }
    }

    // Método para dejar de atacar al enemigo fuera de rango
    public void OnEnemyExit(GameObject enemy)
    {
        // Si el enemigo sale del rango, dejar de estar en la lista de ataque
        enemiesInRange.Remove(enemy);
        // Quita el color del enemigo
        enemy.GetComponent<SpriteRenderer>().color = Color.white;

        // Si el enemigo que sale es el objetivo actual, cambiar de objetivo
        if (currentTarget == enemy)
        {
            if (enemiesInRange.Count > 0)
                currentTarget = enemiesInRange[0];
            else
                currentTarget = null;
        }
    }

    // Método para atacar al enemigo
    private IEnumerator AttackEnemy(GameObject enemy)
    {
        isAttacking = true;
        Debug.Log("Atacando");
        Instantiate(bulletPrefab, aimTransform.transform.position, aimTransform.transform.rotation);
        Instantiate(bulletPrefab, aimTransform.transform.position, aimTransform.transform.rotation * Quaternion.Euler(0, 0, 10));
        Instantiate(bulletPrefab, aimTransform.transform.position, aimTransform.transform.rotation * Quaternion.Euler(0, 0, -10));
        if(levelTower >= 3){
            Instantiate(bulletPrefab, aimTransform.transform.position, aimTransform.transform.rotation * Quaternion.Euler(0, 0, 20));
            Instantiate(bulletPrefab, aimTransform.transform.position, aimTransform.transform.rotation * Quaternion.Euler(0, 0, -20));
        }
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }

    public int LevelTower
    {
        get { return levelTower; }
        set { levelTower = value; }
    }
}
