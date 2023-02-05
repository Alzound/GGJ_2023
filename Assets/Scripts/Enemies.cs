using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int i; 
    public float speed;
    public Transform[] targetPoints;
    public Transform target; 
    public float minimumDistance;
    public bool once;
    public GAMEMANAGER manager;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyBehaviour(); 
        Patrol(); 

    }

    public void EnemyBehaviour()
    {
        if(Vector2.Distance(transform.position, target.position) < minimumDistance) 
        { 
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed* Time.deltaTime);
            //manager.endGame = true; 
        }
    }

    public void Patrol()
    {
        if (transform.position != targetPoints[i].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPoints[i].position, speed * Time.deltaTime);
        }
        if (once == false)
        {
            once = true;
            StartCoroutine(Wait());
        }
    }

    public IEnumerator Wait() 
    {
        animator.SetBool("Left", false);
        animator.SetBool("Right", false);
        animator.SetBool("Up", false);
        animator.SetBool("Down", false);
        yield return new WaitForSeconds(5);
        if(i + 1 < targetPoints.Length)
        {
            i++; 
        }
        else
        {
            i = 0; 
        }
        once = false; 
    }
}
