using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float dashSpeed = 10.0f;
    [SerializeField] private float dashDuration = 0.5f;

    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isDashing = false;
    private float dashTime;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        flipSprite();
        ControlDash();
    }

    void FixedUpdate()
    {
        // Capturar la entrada del jugador 
        movement.x = Input.GetAxis("Horizontal"); 
        movement.y = Input.GetAxis("Vertical");
        // Muevo al jugador
        rb.linearVelocity = movement.normalized * speed * Time.fixedDeltaTime;
    }

    private void flipSprite()
    {
        if(Input.GetAxis("Horizontal") > 0.1)
            sprite.flipX = false;
        if(Input.GetAxis("Horizontal") < -0.1)
            sprite.flipX = true;
    }

    private void ControlDash(){
        if(Input.GetKeyDown(KeyCode.Space) && !isDashing){
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash(){
        isDashing = true;
        dashTime = dashDuration;

        Vector3 dashDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized;

        while(dashTime > 0){
            transform.Translate(dashDirection * dashSpeed * Time.deltaTime);
            dashTime -= Time.deltaTime;
            yield return null;
        }
        isDashing = false;
    }
}
