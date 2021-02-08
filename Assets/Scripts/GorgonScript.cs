using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GorgonScript : MonoBehaviour
{
    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    private float characterVelocity = 2f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    public Transform GorgonHybrid;

    public float speed;
    Rigidbody2D rigidBody;    

    void Start()
    {
        latestDirectionChangeTime = 0f;
        calculateNewMovementVector();
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        rigidBody = GetComponent<Rigidbody2D>();

        Physics2D.IgnoreLayerCollision(8,9);
    }

    void calculateNewMovementVector()
    {
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * characterVelocity;
    }

    void Update()
    {
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calculateNewMovementVector();
        }

        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
        transform.position.y + (movementPerSecond.y * Time.deltaTime));
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            calculateNewMovementVector();
        }
        
        if (col.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
    
}
