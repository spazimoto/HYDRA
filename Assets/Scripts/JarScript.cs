using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    int health;

    public Sprite Jar2;
    public Sprite Jar3;
    public Sprite Jar4;
    public Sprite Jar5;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        health = 100;
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= 20;

            if (health == 80)
            {
                spriteRenderer.sprite = Jar2;
            }

            if (health == 60)
            {
                spriteRenderer.sprite = Jar3;
            }

            if (health == 40)
            {
                spriteRenderer.sprite = Jar4;
            }

            if (health == 20)
            {
                spriteRenderer.sprite = Jar5;
            }

            if (health == 0)
            {
                Destroy(gameObject);
            }
            //animation controller
        }
    }
}
