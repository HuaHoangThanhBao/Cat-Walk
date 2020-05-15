using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpSceneController : MonoBehaviour {

    private void Start()
    {
        Instantiate(Resources.Load("Prefabs/Background_StartUp") as GameObject, Vector3.zero, Quaternion.identity);

        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(4);
        UnityEngine.SceneManagement.SceneManager.LoadScene("CatWalks");
    }
}
