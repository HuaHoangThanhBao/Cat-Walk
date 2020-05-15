using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl : MonoBehaviour {
    
    GameObject edge;

    GameObject backgroundStepZero;
    GameObject backgroundStepOne;
    GameObject backgroundStepTwo;

    CatController player;

    public List<GameObject> background_Clone;

    private void Awake()
    {
        player = FindObjectOfType<CatController>();
        backgroundStepZero = Resources.Load("Prefabs/BackgroundStepZero") as GameObject;
        backgroundStepOne = Resources.Load("Prefabs/BackgroundStepOne") as GameObject;
        backgroundStepTwo = Resources.Load("Prefabs/BackgroundStepTwo") as GameObject;
    }

    private void Start()
    {
        backgroundStepZero = (GameObject)Instantiate(backgroundStepZero, new Vector3(player.variables.startX_B, 0, 0), Quaternion.identity);
        backgroundStepZero.transform.parent = transform;
        background_Clone.Add(backgroundStepZero);

        player.variables.startX_B += 10;
        backgroundStepOne = (GameObject)Instantiate(backgroundStepOne, new Vector3(player.variables.startX_B, 0, 0), Quaternion.identity);
        backgroundStepOne.transform.parent = transform;
        background_Clone.Add(backgroundStepOne);

        player.variables.startX_B += 10;
        backgroundStepTwo = (GameObject)Instantiate(backgroundStepTwo, new Vector3(player.variables.startX_B, 0, 0), Quaternion.identity);
        backgroundStepTwo.transform.parent = transform;
        background_Clone.Add(backgroundStepTwo);
    }

    int temp = 0;

    private void Update()
    {
        if (player.variables.onTriggerBackground)
        {
            if (temp == 0)
            {
                player.variables.startX_B += 10;
                backgroundStepTwo = (GameObject)Instantiate(backgroundStepTwo, new Vector3(player.variables.startX_B, 0, 0), Quaternion.identity);
                backgroundStepTwo.transform.parent = transform;
                background_Clone.Add(backgroundStepTwo);

                Destroy(transform.GetChild(0).gameObject);

                temp++;
            }
        }
        else temp = 0;
    }
}
