using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;
//Components
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Light2D))]

public class Interactable : MonoBehaviour
{
    //private Light light;
    public bool isInRange;
    public UnityEvent interactAction;
    public Animator anim;

    private void Start()
    {
        this.gameObject.GetComponent<Light2D>().pointLightOuterRadius = 1;
        this.gameObject.GetComponent<Light2D>().enabled = false; 
    }

    private void Update()
    {
        if(isInRange == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                interactAction.Invoke(); 
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Player has enter");
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("Player has enter");
            this.gameObject.GetComponent<Light2D>().enabled = true;
            isInRange = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("stay");
        /*
        this.gameObject.GetComponent<Light2D>().pointLightOuterRadius = 1;
        this.gameObject.GetComponent<Light2D>().pointLightOuterRadius = .3f;
        this.gameObject.GetComponent<Light2D>().pointLightOuterRadius = 1;
        //StartCoroutine( LightFlick()); 
        */
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
        this.gameObject.GetComponent<Light2D>().enabled = false;
    }

    public IEnumerator LightFlick()
    {
        Debug.Log("numerator");
        this.gameObject.GetComponent<Light2D>().pointLightOuterRadius = .5f;
        yield return new WaitForSeconds(2f); 
    }
}
