using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyController : MonoBehaviour
{
    //public List<GameObject> player_models;
    //public List<Material> player_materials;
    //public List<GameObject> player_variants;
    public List<CharacterColor> player_colors;
    [SerializeField] string game_scene_name;

    //join

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            UnityEngine.SceneManagement.SceneManager.LoadScene(game_scene_name );
    }
}
