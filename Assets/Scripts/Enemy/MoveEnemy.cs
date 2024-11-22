using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    private SpriteRenderer sprite;
    private NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
        FlipSprite();
        agent.SetDestination(target.position); // Envia al agente a la posición del objetivo
    }

    private void FlipSprite(){
        if(target.position.x > transform.position.x){
            sprite.flipX = false;
        }
        if(target.position.x < transform.position.x){
            sprite.flipX = true;
        }
    }

    public void SetTarget(Transform target){
        this.target = target;
    }
}
