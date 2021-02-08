using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public float timer;
    public GameObject Tap;
    public static bool activated = false;

    public Text startUp;

    void Start()
    {
        startUp.text = "[ Tap SPACE to start ]";
    }

    void exit()
    {
          if (Input.touchCount > 0 && activated == false)
           {
             Tap.SetActive(false);
             activated = true;
           }
    }

    void Update()
    {
        exit();
           timer = timer + Time.deltaTime;
           if(timer >= 0.5)
           {
                   GetComponent<Text>().enabled = true;
           }
           if(timer >= 1)
           {
                   GetComponent<Text>().enabled = false;
                   timer = 0;
           }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("level1");
        }
    }
}
