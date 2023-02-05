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
    public bool once = false;
    public GAMEMANAGER manager;
    public Animator animator;
    [SerializeField] AudioClip levelMusic;
    [SerializeField] AudioClip levelMusicGeneral;

    // Start is called before the first frame update
    void Start()
    {
        once = false; 
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
            AudioManager_1.instance.PlayMusic(levelMusic);
        }
    }

    public void Patrol()
    {
        if (transform.position != targetPoints[i].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPoints[i].position, speed * Time.deltaTime);

        }else 
        {
            if (once == false)
            {
                Debug.Log("once"); 
                once = true;
                StartCoroutine(Wait());
            }
        }
        
    }

    public IEnumerator Wait() 
    {
        animator.SetBool("Left", false);
        animator.SetBool("Right", false);
        animator.SetBool("Up", false);
        animator.SetBool("Down", false);
        yield return new WaitForSeconds(3);
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
