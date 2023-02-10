using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public bool solves = false;
    public String thisTag; 

    private void Start()
    {
        thisTag = gameObject.tag;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("entro");
        if (collision.CompareTag("BoxGreen"))
        {
            Debug.Log("green"); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Centro");
        if (collision.gameObject.CompareTag("BoxGreen"))
        {
            Debug.Log("Cgreen");
        }
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("BoxGreen"))
        {
            Debug.Log("Correcto");
            solves = true;
        }
        /*
        if (collision.CompareTag("BoxYwllow"))
        {
            Debug.Log("Correcto");
            solves = true;
        }
        if (collision.CompareTag("BoxBlue"))
        {
            Debug.Log("Correcto");
            solves = true;
        }
        if (collision.CompareTag("BoxRed"))
        {
            Debug.Log("Correcto");
            solves = true;
        }
        */
    //}


}