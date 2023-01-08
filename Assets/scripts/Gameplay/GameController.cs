using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float gameDurationTime = 10;
    public Text timerTXT;

    private void Update()
    {
        // hotkey to reset the current scene
        if (Input.GetKeyDown(KeyCode.T))
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.
                SceneManager.GetActiveScene().name);

        // countdown timer logic and UI updates
        if(gameDurationTime > 0)
        {
            gameDurationTime -= Time.deltaTime;
            timerTXT.text = Mathf.FloorToInt(gameDurationTime / 60) + ":" + Mathf.FloorToInt(gameDurationTime % 60);
        }
        else // timer has expired
        {
            print("game done");
        }
    }


}
