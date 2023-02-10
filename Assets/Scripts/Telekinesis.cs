//codigo para objeto telekinetico
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//Components
[RequireComponent(typeof(BoxCollider2D))]
//[RequireComponent(typeof(PrefabAssetType))]

public class Telekinesis : MonoBehaviour
{
    public ParticleSystem power; 
    public int rangeOfPower;
    public bool isTelekinetic, nullify = false;
    public Color initialColor;
    public GameObject player; 
    public Vector2 playerInfo, me; 


    private void Start()
    {
       initialColor = this.gameObject.GetComponent<SpriteRenderer>().color;
       playerInfo = player.transform.position;
       power.gameObject.SetActive(false); 
    }

    private void Update()
    {
        playerInfo = player.transform.position;
        //Debug.Log(Vector2.Distance(playerInfo, me));
    }

    private void OnMouseOver()
    {
        if(nullify == false)
        {
            //Debug.Log("Mouse over");
            if (Vector2.Distance(playerInfo, me) <= rangeOfPower)
            {
                power.gameObject.SetActive(true);
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                isTelekinetic = true;
            }
            if (Vector2.Distance(playerInfo, me) > rangeOfPower)
            {
                power.gameObject.SetActive(false);
                this.gameObject.GetComponent<SpriteRenderer>().color = initialColor;
                isTelekinetic = false;
            }
        }
    }
    private void OnMouseDrag()
    {
        if (nullify == false)
        {
            if (isTelekinetic == true && Vector2.Distance(playerInfo, me) <= rangeOfPower)
            {
                this.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
    }

    private void OnMouseExit()
    {
        //Debug.Log("Mouse exit");
        power.gameObject.SetActive(false);
        this.gameObject.GetComponent<SpriteRenderer>().color = initialColor;
        isTelekinetic = false;
    }

    public void BoostRange()
    {
        rangeOfPower = 4; 
    }

    public void RestoreRange()
    {
        rangeOfPower = 2;
    }
    
}
