using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro; 

public class Solve : MonoBehaviour
{
    public Puzzle pice1;
    public Puzzle pice2;
    public Puzzle pice3;
    public Puzzle pice4;
    public Color firstColor;
    public bool end;
    public Light2D globalLight;
    public TextMeshProUGUI endPanel; 

    // Start is called before the first frame update
    void Start()
    {
        firstColor = this.gameObject.GetComponent<SpriteRenderer>().color;
        end = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (pice1.solves == true && pice2.solves == true && pice3.solves == true && pice4.solves == true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            end = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && end  == true)
        {
            collision.GetComponent<Player_Controller>().game = false;
            globalLight.intensity = 0.1f;
            endPanel.gameObject.SetActive(true);
            StartCoroutine(endGame());
        }
    }

    public IEnumerator endGame()
    {
        yield return new WaitForSeconds(10); 
        Application.Quit(); 
    }
}