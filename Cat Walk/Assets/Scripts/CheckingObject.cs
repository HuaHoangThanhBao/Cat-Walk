using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingObject : MonoBehaviour {

    public enum ObjectType
    {
        Ground,
        Edge
    }

    public ObjectType objectType;

    public LayerMask mask; //Ground + Edge

    CatController player;

    private void Awake()
    {
        player = FindObjectOfType<CatController>();
    }

    private void FixedUpdate()
    {
        //Debug.DrawRay(this.transform.position, Vector2.down * player.variables.range, Color.blue, 1);

        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, player.variables.range, mask);

        if(hit.collider != null)
        {
            if(hit.transform.tag == "Ground")
            {
                objectType = ObjectType.Ground;
            }

            else if (hit.transform.tag == "Edge")
            {
                objectType = ObjectType.Edge;
            }
        }
    }

}
