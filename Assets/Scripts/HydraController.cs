using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraController : MonoBehaviour
{
    public float speed;
    public Transform body;

    public GameObject lives;

    public void Start()
    {
        // instantiate x number of children behind head
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        int bodyCount = transform.childCount;

        if ((col.gameObject.CompareTag("Wall")) || (col.gameObject.CompareTag("Obstacle")))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed); //working
            transform.Rotate(0, 0, 180); //working
            transform.position += Vector3.down; // hydra moves down one unit when it hits wall

            Debug.Log("Found the wall!"); //working
        }

        if (col.gameObject.CompareTag("Bullet"))
            {
                if (bodyCount >= 1)
                { 
                    Destroy(transform.GetChild(bodyCount - 1).gameObject); // if bodyCount >= 1, destroy last child in list
                }
                 else 
                {
                    Destroy(gameObject);
                } 
            }

        if (col.gameObject.CompareTag("Player"))
        {
            lives.SendMessage("TakeDamage", 1);
        }
    }
}
