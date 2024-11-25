using UnityEngine;

public class ShotgunBullet : MonoBehaviour
{
    [SerializeField] private float speed = 200f;
    public float timeDestroy = 2f;
    private float damage = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Gira el sprite 90 grados en el eje Z ya que el sprite está orientado hacia arriba
        transform.Rotate(0, 0, -90);
        Destroy(gameObject, timeDestroy);
        //if(transform.parent.parent.gameObject.GetComponent<AttackTower>().LevelTower == 2)
        //    damage = 4f;
    }

    void Update()
    {
        // Mueve el objeto hacia adelante
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public float Damage
    {
        get { return damage; }
    }
}
