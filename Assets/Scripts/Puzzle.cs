using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public bool solves = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (this.tag == collision.tag)
        {
            Debug.Log("Correcto");
            solves = true;
        }
    }
}