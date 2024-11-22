using UnityEngine;
using UnityEngine.Tilemaps;

public class CloudMove : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private Vector3 respawnPoint;
    [SerializeField] private float respawnXPosition = 10.0f;
    [SerializeField] private float leftBoundary = -10.0f;

    private Tilemap tilemap;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < leftBoundary)
        {
            RespawnTilemap();
        }
    }

    void RespawnTilemap()
    {
        // Reposiciona el Tilemap a la derecha fuera de la cámara
        transform.position = respawnPoint;
    }
}
