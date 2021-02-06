using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour
{

    public GameObject[] lives;
    private int life;
    private bool dead;
    public Text message;

    public ColliderListener colliderScript;

    private void Start()
    {
        GameObject hydraEnemy = GameObject.Find("Hydra");
        ColliderListener colliderScript = hydraEnemy.GetComponent<ColliderListener>();

        life = lives.Length;

        Time.timeScale = 0;
        message.text = "Welcome to HYDRA! \n\n Use WASD to move \n Press E to shoot \n ESCAPE to quit the game \n\n Press SPACE to begin!";
    }

    void Update()
    {
        
        if (dead == true)
        {
            Debug.Log("The player has died!");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            message.gameObject.SetActive(false);
        }

        Debug.Log("Player's score is " + colliderScript.score);

        if (colliderScript.score == 3)
        {
            message.gameObject.SetActive(true);
            message.text = "Congratulations, you've slain the HYDRA! \n Press R to play again.";

            if (Input.GetKeyDown(KeyCode.R))
                {
                    Scene scene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(scene.name);
                }
        }
    }

    public void TakeDamage(int damage)
    {
        if (life >= 1)
        {
            life -= damage;
            Destroy(lives[life].gameObject);

            if(life < 1)
            {
                dead = true;

                message.gameObject.SetActive(true);
                message.text = "You died! Press R to restart.";

                if (Input.GetKeyDown(KeyCode.R))
                {
                    Scene scene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(scene.name);
                }
            }
        }
    }
}
