using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowEffect : MonoBehaviour {

    Vector3 offset = (new Vector3(0.4f, -2.7f, 0));

    CatController player;

    GameObject shadow;

    public LayerMask mask; //Edge

    private void Awake()
    {
        player = FindObjectOfType<CatController>();
        shadow = GameObject.Find("Shadow");
    }

    private void Update()
    {
        if (!player.variables.falling_B && !player.variables.falling_T)
            this.transform.position = new Vector3(player.transform.position.x + offset.x, offset.y, offset.z);
    }

    private void FixedUpdate()
    {
        //Debug.DrawRay(this.transform.position, Vector2.right * 0.5f, Color.black, 1);

        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.right, 0.7f, mask);

        if (hit.collider != null)
        {
            if (hit.transform.tag == "EdgeBellow")
            {
                shadow.gameObject.SetActive(false);
            }
        }
        else shadow.gameObject.SetActive(true);
    }
}
