using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solve : MonoBehaviour
{
    public Puzzle pice1;
    public Puzzle pice2;
    public Puzzle pice3;
    public Puzzle pice4;
    public Color firstColor;

    // Start is called before the first frame update
    void Start()
    {
        firstColor = this.gameObject.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (pice1.solves == true && pice2.solves == true && pice3.solves == true && pice4.solves == true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}