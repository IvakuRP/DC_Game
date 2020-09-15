using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour {

    public GameObject[] player;
    public int playerChoose;

    public Transform spawnPoint;

    void Awake()
    {
        playerChoose = PlayerProfile.instace.covySelected;

        Spawn(playerChoose);
    }

    void Spawn(int covy)
    {
        Instantiate(player[covy], spawnPoint.position, spawnPoint.rotation);
    }
}
