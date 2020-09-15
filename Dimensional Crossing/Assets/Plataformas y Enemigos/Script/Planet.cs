using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

    public static Planet instance;
    public SpriteRenderer planetSR;

    public int speed;

    public Sprite[] platformSprites;
    public int currentSprite;

	void Start (){
        instance = this;

        planetSR = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
        transform.RotateAround(transform.position, Vector3.back, speed * Time.deltaTime);
	}

    public void DefineSprite(){
        currentSprite = Random.Range(0, platformSprites.Length);
        planetSR.sprite = platformSprites[currentSprite];
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
            Destroy(gameObject, 2.0f);
    }
}
