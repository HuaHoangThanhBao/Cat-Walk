using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCheck : MonoBehaviour {
    
    public LayerMask mask; //Ground + Edge

    CatController player;

    private void Awake()
    {
        player = FindObjectOfType<CatController>();
    }

    private void Update()
    {
        //Debug.DrawRay(transform.position, Vector2.down * maxDistance, Color.black, 1);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, player.variables.maxDistance, mask);

        if (hit.collider == null)
        {
            player.variables.onAir = true;
        }
        else player.variables.onAir = false;
    }
}
