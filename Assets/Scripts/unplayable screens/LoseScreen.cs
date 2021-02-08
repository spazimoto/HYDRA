using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    Text message;
    void Start()
    {
        message = gameObject.GetComponent<Text>();

        message.text = "The HYDRA has devoured you! \n Tap R to restart the game.";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("start");
        }
    }
}
