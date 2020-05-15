using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {
    
    public LayerMask mask; //Check point + Strawberry

    CatController player;

    private void Awake()
    {
        player = FindObjectOfType<CatController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "CheckPoint")
        {
            player.variables.hitCheckPoint = true;

            temp = 0;

            if (collision.transform.tag == "Strawberry")
            {
                player.variables.hitStrawberry = true;
            }
        }

        else if(collision.transform.tag == "Strawberry")
        {
            player.variables.hitStrawberry = true;
        }
    }

    int temp = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "CheckPoint")
        {
            player.variables.hitCheckPoint = false;

            if (temp == 0)
            {
                temp++;
            }

            if (collision.transform.tag == "Strawberry")
            {
                player.variables.hitStrawberry = false;
            }
        }
        
        else if (collision.transform.tag == "Strawberry")
        {
            player.variables.hitStrawberry = false;
        }
    }
}
