using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBackChecking : MonoBehaviour {
    
    public LayerMask mask; //Ground + Edge

    CatController player;

    private void Awake()
    {
        player = FindObjectOfType<CatController>();
    }

    private void Update()
    {
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.left) * distanceOfRaycast, Color.red, 1);
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.left) * 1.5f, Color.green, 1);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), player.variables.distanceOfRaycast_B, mask);

        RaycastHit2D hitB = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 1.5f, mask);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Ground")
            {
                player.variables.falling_B = true;
            }
        }

        if(hitB.collider != null)
        {
            if(hitB.collider.tag == "Ground")
            {
                player.variables.hitGround_B = true;
            }
        }

        if(hitB.collider != null)
        {
            if (hitB.collider.tag == "EdgeLeft" || hitB.collider.tag == "EdgeRight" || hitB.collider.tag == "EdgeBellow")
            {
                player.variables.hitGround_B = true;
                player.variables.hitEdge_B = true;
            }
        }
    }

}
