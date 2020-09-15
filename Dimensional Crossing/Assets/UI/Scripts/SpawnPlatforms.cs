using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour
{
    public static SpawnPlatforms instace;

    public GameObject[] platforms;
    public int currentPlatform;

    public Transform[] areaspawn;
    public int currentArea;
    public bool spawnPlatform;

    void Start()
    {
        instace = this;
        spawnPlatform = true;
    }

    void Update()
    {
        if (spawnPlatform)
            SpawnPlatform();
    }

    void SpawnPlatform()
    {
        currentPlatform = Random.Range(0, platforms.Length);
        currentArea = Random.Range(0, areaspawn.Length);

        Instantiate(platforms[currentPlatform], areaspawn[currentArea].position, areaspawn[currentArea].rotation);

        Planet.instance.DefineSprite();

        spawnPlatform = false;
    }
}