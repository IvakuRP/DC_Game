using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour{

    private void OnTriggerEnter2D(Collider2D objectCollider)
    {
        Player.instance.shield = true;
        SFXManeger.instance.PlaySFX(SFXType.POWERUP_TAKE);
        Destroy(this.gameObject);
    }
}
