//Player
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Player_Controller : MonoBehaviour
{
    public float speedOfMovement;
    public int pushForce;
    public bool game; 

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<BoxCollider2D>().size =new Vector2(2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if(game == true)
        {
            Movement();

        }
    }

    public void Movement()
    {
        //Movement
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position = transform.position - transform.right * speedOfMovement * Time.deltaTime; 
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position = transform.position + transform.right * speedOfMovement * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position = transform.position + transform.up * speedOfMovement * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position = transform.position - transform.up * speedOfMovement * Time.deltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {    
        //Push power
        if (Input.GetKey(KeyCode.Space))
        {
            if (collision.CompareTag("enemies"))
            {
                
                if (collision.gameObject.transform.rotation.eulerAngles.z >= 0 && collision.gameObject.transform.rotation.eulerAngles.z <= 89)
                {
                    Debug.Log("up");
                    collision.GetComponent<Rigidbody2D>().AddForce(-Vector2.up * Time.deltaTime * pushForce * 10);
                }
                if (collision.gameObject.transform.rotation.eulerAngles.z >= 90 && collision.gameObject.transform.rotation.eulerAngles.z <= 179)
                {
                    Debug.Log("right");
                    collision.GetComponent<Rigidbody2D>().AddForce(Vector2.right * Time.deltaTime * pushForce * 10);
                }
                if (collision.gameObject.transform.rotation.eulerAngles.z >= 180 && collision.gameObject.transform.rotation.eulerAngles.z <= 269)
                {
                    Debug.Log("down");
                    collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Time.deltaTime * pushForce * 10);
                }
                if (collision.gameObject.transform.rotation.eulerAngles.z >= 270 && collision.gameObject.transform.rotation.eulerAngles.z <= 360)
                {
                    Debug.Log("left");
                    collision.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * Time.deltaTime * pushForce * 10);
                }
            }
        }      
    }

    public void StopPowerAndMovement()
    {
        speedOfMovement = .5f;
        pushForce = 0; 
    }

    public void RestorePowerAndMovement()
    {
        speedOfMovement = 2;
        pushForce = 25;
    }

    public void BoostSpeedAndPower()
    {
        speedOfMovement = 4;
        pushForce = 35;
    }
}
