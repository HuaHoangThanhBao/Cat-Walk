using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrawberryCollision : MonoBehaviour {

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
