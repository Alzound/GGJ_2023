using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Menu : MonoBehaviour
{
    public GameObject menu; 
    public GameObject credits;
    public GameObject buttons, returnButton; 
    //public Player_Controller player; 

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Credits()
    {
        credits.SetActive(true); 
        returnButton.SetActive(true);
    }

    public void Return()
    {
        credits.SetActive(false);
        buttons.SetActive(true);
        returnButton.SetActive(false);   
    }

    public void Quit()
    {
        Application.Quit();
    }
}
