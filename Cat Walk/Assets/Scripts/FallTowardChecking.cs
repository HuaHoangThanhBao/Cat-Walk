using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTowardChecking : MonoBehaviour {

    public LayerMask mask; //Ground + Edge

    CatController player;

    private void Awake()
    {
        player = FindObjectOfType<CatController>();
    }

    private void FixedUpdate()
    {
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * distanceOfRaycast, Color.red, 1);
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * 1.5f, Color.green, 1);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), player.variables.distanceOfRaycast_T, mask);
        
        RaycastHit2D hitT = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 1.5f, mask);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Ground")
            {
                player.variables.falling_T = true;
            }
        }


        if (hitT.collider != null)
        {
            if (hitT.collider.tag == "Ground")
            {
                player.variables.hitGround_T = true;
            }
        }

        if (hitT.collider != null)
        {
            if (hitT.collider.tag == "EdgeLeft" || hitT.collider.tag == "EdgeRight" || hitT.collider.tag == "EdgeBellow")
            {
                player.variables.hitGround_T = true;
                player.variables.hitEdge_T = true;
            }
        }
    }
}
