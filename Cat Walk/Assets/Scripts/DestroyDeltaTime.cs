using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyDeltaTime : MonoBehaviour {

    public FallBackChecking f_b_c;
    public FallTowardChecking f_t_t;

    public List<GameObject> edgeClones;
    public List<GameObject> backgroundClones;
    public List<GameObject> checkPointClone;

    private void Start()
    {
        edgeClones = new List<GameObject>();
        backgroundClones = new List<GameObject>();
    }

    public void AddCheckPointClone(GameObject a)
    {
        checkPointClone.Add(a);
    }

    private void Update()
    {
        if(transform.childCount % 4 == 0 && transform.childCount != 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }

    public void AddEdgeClone(GameObject a)
    {
        edgeClones.Add(a);
    }

    public void AddBackgroundClone(GameObject a)
    {
        backgroundClones.Add(a);
    }
}
