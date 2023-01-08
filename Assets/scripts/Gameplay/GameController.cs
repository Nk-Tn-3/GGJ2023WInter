using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float end_duration = 10f;
    public float gameDurationTime = 10;
    public Text timerTXT;
    public GameObject endscreen;


    [SerializeField] string lobby_scene_name;
    [SerializeField] List<GameObject> disable_list;

    private void Awake()
    {
        endscreen.SetActive(false);
    }

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
            /*UnityEngine.SceneManagement.SceneManager.LoadScene(lobby_scene_name);*/
            EndGame();
        }
    }

    private void EndGame()
    {
        Invoke(nameof(Leave), end_duration);
        foreach(GameObject disable in disable_list)
        {
            disable.SetActive(false);
        }
        endscreen.SetActive(true);
    }

    private void Leave()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(lobby_scene_name);
    }
}
