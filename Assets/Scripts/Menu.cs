using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject menu; 
    public GameObject credits;
    public Player_Controller player; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        menu.SetActive(false); 
        player.game = true; 
    }

    public void Credits()
    {
        credits.SetActive(true); 
    }

    public void Return()
    {
        credits.SetActive(false);
        menu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
