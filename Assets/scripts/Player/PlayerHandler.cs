using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public int player_id = 0;
    [SerializeField] GameObject player_object;
    [SerializeField] MeshRenderer player_mesh;

    private void Awake()
    {
        //add later
        //GetComponent<PlayerInteract>().Initialize();
        //GetComponent<PlayerMovement>().Initialize();

        player_id = GameManager.instance.Players.Count;
        GameManager.instance.Players.Add(gameObject);
        gameObject.transform.SetParent(GameManager.instance.transform);

        //swap out player apearances
        player_mesh.material = GameObject.FindGameObjectWithTag("Lobby_Controller").GetComponent<LobbyController>().player_materials[player_id];
    }
}