using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //test

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.
                SceneManager.GetActiveScene().name);
    }
}
