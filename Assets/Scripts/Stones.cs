using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stones : MonoBehaviour
{
    private bool nullify, bSpeed, bRange;  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.gameObject.CompareTag("nullify") && other.gameObject.CompareTag("Player"))
        {
            nullify = true; 
            other.gameObject.GetComponent<Player_Controller>().StopPowerAndMovement();
            other.gameObject.GetComponent<Telekinesis>().nullify = true;
        }

        if (this.gameObject.CompareTag("boostSpeed") && other.gameObject.CompareTag("Player"))
        {
            bSpeed = true;
            other.gameObject.GetComponent<Player_Controller>().BoostSpeedAndPower();
        }

        if (this.gameObject.CompareTag("boostRange") && other.gameObject.CompareTag("Player"))
        {
            bRange = true;
            other.gameObject.GetComponent<Telekinesis>().BoostRange();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(nullify == true)
        {
            other.gameObject.GetComponent<Player_Controller>().RestorePowerAndMovement();
            other.gameObject.GetComponent<Telekinesis>().nullify = false;
            nullify = false;
        }
        if(bSpeed == true) 
        {
            other.gameObject.GetComponent<Player_Controller>().RestorePowerAndMovement();
            bSpeed= false;
            //other.gameObject.GetComponent<Telekinesis>().
        }
        if (bRange == true)
        {
            other.gameObject.GetComponent<Telekinesis>().RestoreRange();
            bRange = false;
            //other.gameObject.GetComponent<Telekinesis>().
        }
    }
}
