using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Menu : MonoBehaviour
{
    public GameObject menu; 
    public GameObject credits;
    public GameObject buttons, returnButton, intro; 
    //public Player_Controller player; 

    public void Play()
    {
        //intro.SetActive(true);
        buttons.SetActive(false);
        StartCoroutine(WaitIntro());
        
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

    public IEnumerator WaitIntro()
    {
        intro.SetActive(true);
        yield return new WaitForSeconds(10);
         
        SceneManager.LoadScene(1);  
    }
}
