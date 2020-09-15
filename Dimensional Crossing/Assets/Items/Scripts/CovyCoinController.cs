using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CovyCoinController : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D objectCollider)
    {
        PlayerProfile.instace.AddCoin();
        SFXManeger.instance.PlaySFX(SFXType.COIN);
        Destroy(this.gameObject);
    }
}
