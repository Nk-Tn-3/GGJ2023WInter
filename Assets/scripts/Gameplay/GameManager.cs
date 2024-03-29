using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public List<GameObject> players;
    public static GameManager instance;

    private void Awake()
    {
        if (GameManager.instance != null && GameManager.instance != this)
            Destroy(gameObject);
        else
        {
            GameManager.instance = this;
            SoundManager.instance = GetComponentInChildren<SoundManager>();
            DontDestroyOnLoad(gameObject);
            players = new List<GameObject>();
        }
    }
}
