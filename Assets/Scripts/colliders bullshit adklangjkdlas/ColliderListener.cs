using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderListener : MonoBehaviour
{
    public int score;
    void Awake()
    {
         Collider2D[] colliders = GetComponentsInChildren<Collider2D>();

        foreach(Collider2D collider in colliders) {
            if (collider.gameObject != gameObject)
            {
                ColliderBridge cb = collider.gameObject.AddComponent<ColliderBridge>();
                cb.Initialize(this);
            }
        }
    }

    void Start()
    {
        score = 0;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            score += 1;
        }
    }
}
