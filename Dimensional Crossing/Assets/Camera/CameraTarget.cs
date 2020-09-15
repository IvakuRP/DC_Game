using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour {

    public static CameraTarget instance;

    public bool moveCam;

    private void Start()
    {
        instance = this;

        moveCam = false;
    }

    void Update()
    {

        if(moveCam)
        {
            transform.position = transform.position + new Vector3(0.0f, 6.5f, 0.0f);
            moveCam = false;
            SpawnPlatforms.instace.spawnPlatform = true;
        }
    }
}
