using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    CatController player;

    Vector3 offset = new Vector3(0, 0, -10);

    private void Awake()
    {
        player = FindObjectOfType<CatController>();
    }

    private void LateUpdate()
    {
        Vector3 desiredPos = new Vector3(player.transform.position.x, 0, player.transform.position.z + offset.z);

        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, player.variables.smoothSpeed);

        transform.position = smoothPos;
    }
}
