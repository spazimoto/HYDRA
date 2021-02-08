using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour {

    public GameObject[] lives;
    private int life;
    private bool dead;

    public Text message;

    public ColliderListener colliderScript;

    private void Start () 
    {

        GameObject hydraEnemy = GameObject.Find ("Hydra");
        ColliderListener colliderScript = hydraEnemy.GetComponent<ColliderListener> ();

        life = lives.Length;
        message.gameObject.SetActive (false);
    }

    void Update () 
    {
        if (dead == true) 
        {
            Debug.Log ("The player has died!");
        }
        Debug.Log ("Player's score is " + colliderScript.score);

        if (colliderScript.score == 10) 
        {
                SceneManager.LoadScene ("level2");
                
                if ((colliderScript.score == 10) && (SceneManager.GetActiveScene ()== SceneManager.GetSceneByName ("level2")))
                {
                    SceneManager.LoadScene("win");
                }
            
        }
    }

    public void TakeDamage (int damage) 
    {
        if (life >= 1) 
        {
            life -= damage;
            Destroy (lives[life].gameObject);

            if (life < 1) 
            {
                dead = true;
                SceneManager.LoadScene ("loss");
            }
        }
    }
}