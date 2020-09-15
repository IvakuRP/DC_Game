using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeat : MonoBehaviour {

    private BoxCollider2D binaryCollider;
    private float binaryVeticalLenght;

	void Start () {
        binaryCollider = GetComponent<BoxCollider2D>();
        binaryVeticalLenght = binaryCollider.size.y;
	}
	
	void Update () {
        if (transform.position.y < -binaryVeticalLenght)
            Reposition();
	}

    private void Reposition()
    {
        Vector2 backgroundOffset = new Vector2(0, binaryVeticalLenght * 2);
        transform.position = (Vector2)transform.position + backgroundOffset;
    }
}
