using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesItem : MonoBehaviour {

    public GameObject[] enemies;
    public int enemyChoose;
    public bool spawn;

    public Transform[] areaspawn;
    public int areaChoose;

    public GameObject shield;
    public bool spawnShield;
    public int points;

    public GameObject coin;
    public bool spawncoin;
    public int valuespawncoin;

    private void Awake()
    {
        spawn = false;
        points = PlayerProfile.instace.score;
        valuespawncoin = Random.Range(0, 10);
    }

    void Update () {
        points = PlayerProfile.instace.score;
        


        if (!spawn)
        {
            if (points >= 100 && points <= 199)
                OneEnemy();
            else if (points >= 200 && points <= 299)
                TwoEnemies();
            else if (points >= 300)
                ThreeEnemies();
        }

        if (enemyChoose == 2 && !spawnShield)
            SpawnShield();

        if ((valuespawncoin == 2 || valuespawncoin == 5 || valuespawncoin == 9) && !spawncoin)
                SpawnCoin();
    }

    void OneEnemy()
    {
        enemyChoose = Random.Range(0, enemies.Length);
        areaChoose = Random.Range(0, areaspawn.Length);

        GameObject malwareSon = Instantiate(enemies[enemyChoose], areaspawn[areaChoose].position, areaspawn[areaChoose].rotation);

        malwareSon.transform.parent = areaspawn[areaChoose].transform;
        malwareSon.transform.position = areaspawn[areaChoose].transform.position;

        spawn = true;
    }

    void TwoEnemies()
    {
        int enemyChoose1 = Random.Range(0, enemies.Length);
        int enemyChoose2 = Random.Range(0, enemies.Length);
        int areaChoose1 = 0;
        int areaChoose2 = 2;

        GameObject malwareSon1 = Instantiate(enemies[enemyChoose1], areaspawn[areaChoose1].position, areaspawn[areaChoose1].rotation);
        GameObject malwareSon2 = Instantiate(enemies[enemyChoose2], areaspawn[areaChoose2].position, areaspawn[areaChoose2].rotation);

        malwareSon1.transform.parent = areaspawn[areaChoose1].transform;
        malwareSon1.transform.position = areaspawn[areaChoose1].transform.position;

        malwareSon2.transform.parent = areaspawn[areaChoose2].transform;
        malwareSon2.transform.position = areaspawn[areaChoose2].transform.position;

        spawn = true;
    }

    void ThreeEnemies()
    {
        int enemyChoose1 = Random.Range(0, enemies.Length);
        int enemyChoose2 = Random.Range(0, enemies.Length);
        int enemyChoose3 = Random.Range(0, enemies.Length);
        int areaChoose1 = 0;
        int areaChoose2 = 2;
        int areaChoose3 = 1;

        GameObject malwareSon1 = Instantiate(enemies[enemyChoose1], areaspawn[areaChoose1].position, areaspawn[areaChoose1].rotation);
        GameObject malwareSon2 = Instantiate(enemies[enemyChoose2], areaspawn[areaChoose2].position, areaspawn[areaChoose2].rotation);
        GameObject malwareSon3 = Instantiate(enemies[enemyChoose3], areaspawn[areaChoose3].position, areaspawn[areaChoose3].rotation);

        malwareSon1.transform.parent = areaspawn[areaChoose1].transform;
        malwareSon1.transform.position = areaspawn[areaChoose1].transform.position;

        malwareSon2.transform.parent = areaspawn[areaChoose2].transform;
        malwareSon2.transform.position = areaspawn[areaChoose2].transform.position;

        malwareSon3.transform.parent = areaspawn[areaChoose3].transform;
        malwareSon3.transform.position = areaspawn[areaChoose3].transform.position;

        spawn = true;
    }

    void SpawnShield()
    {
        areaChoose = Random.Range(0, areaspawn.Length);

        GameObject shieldSon = Instantiate(shield, areaspawn[areaChoose].position, areaspawn[areaChoose].rotation);

        shieldSon.transform.transform.parent = areaspawn[areaChoose].transform;
        shieldSon.transform.position = areaspawn[areaChoose].transform.position;

        spawnShield = true;
    }

    void SpawnCoin()
    {
        areaChoose = Random.Range(0, areaspawn.Length);

        GameObject coinSon = Instantiate(coin, areaspawn[areaChoose].position, areaspawn[areaChoose].rotation);

        coinSon.transform.transform.parent = areaspawn[areaChoose].transform;
        coinSon.transform.position = areaspawn[areaChoose].transform.position;

        spawncoin = true;
    }
}
