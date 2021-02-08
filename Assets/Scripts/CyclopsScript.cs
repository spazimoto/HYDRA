using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclopsScript : MonoBehaviour
{
    Vector3 spawnArea;
    public GameObject lives;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(10, 11);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
