using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public int player_id = 0;
    [SerializeField] GameObject player_object;
    [SerializeField] MeshRenderer player_mesh;
    [SerializeField] Material shirt_material;

    private void Awake()
    {
        //add later
        //GetComponent<PlayerInteract>().Initialize();
        //GetComponent<PlayerMovement>().Initialize();

        player_id = GameManager.instance.players.Count;
        GameManager.instance.players.Add(gameObject);
        gameObject.transform.SetParent(GameManager.instance.transform);
        print("Player id: " + player_id);

        //swap out player apearances
        /*GetComponent<PlayerColor>().color*/ 
        GetComponent<Player>().InitializeColor(GameObject.FindGameObjectWithTag("Lobby_Controller").GetComponent<LobbyController>().player_colors[player_id]);
        PlayerColor player_color = new PlayerColor(GetComponent<Player>(), GameObject.FindGameObjectWithTag("Lobby_Controller").GetComponent<LobbyController>().player_colors[player_id]);//
        //shirt_material = GameObject.FindGameObjectWithTag("Lobby_Controller").GetComponent<LobbyController>().player_materials[player_id];
        //player_mesh.material = GameObject.FindGameObjectWithTag("Lobby_Controller").GetComponent<LobbyController>().player_materials[player_id];
    }
}
