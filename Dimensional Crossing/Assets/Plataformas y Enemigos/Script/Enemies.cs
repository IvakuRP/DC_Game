using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D objectCollider){

        if(objectCollider.transform.tag == "Player"){
            if(Player.instance.shield)
                Destroy(this.gameObject);
        }
    }
}
