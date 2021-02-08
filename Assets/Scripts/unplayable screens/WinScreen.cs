using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    Text message;
    void Start()
    {
        message = gameObject.GetComponent<Text>();

        message.text = "Congratulations! \n You've slain the HYDRA! \n\n Tap SPACE to continue."; //remember to make hydra graphic
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            message.text = "Developers: \n Morgan DeMunck - Lead Programmer \n Franza Gregoire - Lead Designer \n Alexander Shopovik - Lead Artist \n\n Thank you for playing!";
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
