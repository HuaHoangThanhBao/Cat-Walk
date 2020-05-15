using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBackCollision : MonoBehaviour {

    public bool onCollision;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            onCollision = true;

            Debug.Log("yes");
        }
    }

}
