using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player instance; //Intancia del Jugador

    public float covyJumpForce; //Fuerza de Salto
    public Animator covyAnimator; //Animator
    public Rigidbody2D covyRigidboddy; //Rigidbody

    private Touch currentTouch; //Touch
    public float countShield; //Cuenta para el Escudo
    public bool shield; //Escudo Activo
    bool firstJump; //Activar Salto
    public bool dance; //Activar baile

    public float radio, velocidadRotacion; //velocidadRotacion de 1 a 180, es el ángulo, en negativo cambia la dirección
    private bool onLand;
    private Vector2 centroPlaneta;
    private float ang;

    void Start()
    {
        instance = this;

        ang = 0;
        shield = false;
        onLand = false;
        countShield = 0;
        firstJump = false;
        covyAnimator = GetComponent<Animator>();
        covyRigidboddy = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (shield == true && countShield == 0)
            ShieldOn();

        if (countShield >= 30)
            ShieldOff();

        if (dance == false)
            StartCoroutine(Dance());

        if (onLand)
        {
            covyRigidboddy.velocity = Vector2.zero;
            transform.position = new Vector3(radio * Mathf.Cos(ang * Mathf.PI / 180.0f) + centroPlaneta.x, radio * Mathf.Sin(ang * Mathf.PI / 180.0f) + centroPlaneta.y);

            transform.localEulerAngles = new Vector3(0.0f, 0.0f, ang - 90.0f);

            ang += velocidadRotacion;
            //para que se desactive la bandera y se detecte la colisión
            //sino el transform no sé porqué no permite la colision

#if UNITY_STANDALONE || UNTYEDITOR //Codigo a ejecutar en PC
            if (Input.GetKeyDown(KeyCode.Space) && firstJump == true)
                covyAnimator.SetTrigger("Jumping");   
#endif

#if UNITY_ANDROID || UNITY_IOS //Codigo a ejecutar en Mobile
            if (Input.touchCount > 0 && firstJump == true)
            {
                currentTouch = Input.GetTouch(0);
                if(currentTouch.position.y < Screen.height * 0.75f)
                {
                    covyAnimator.SetTrigger("Jumping");
                    onLand = false;
                    Jump();
                }  
            }
               
#endif 
        }
    }

    public void Jump()
    {
        onLand = false;
        firstJump = false;
        covyRigidboddy.AddForce(transform.up * covyJumpForce, ForceMode2D.Impulse);
        onLand = false;
    }

    void Dying()
    {
        covyRigidboddy.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        covyAnimator.SetTrigger("Dying");
    }

    public void Turn()
    {
        covyAnimator.SetTrigger("Idle");
    }

    
    void OnCollisionEnter2D(Collision2D objectCollision)
    {
        if (objectCollision.transform.tag == "FirstPlatform" || objectCollision.gameObject.tag == "Platform" || objectCollision.gameObject.tag == "PlatformElect" || objectCollision.gameObject.tag == "PlatformSpike")
        { 
            if (!onLand)
            {
                onLand = true;
                centroPlaneta = objectCollision.transform.position;
                firstJump = true;
                Vector2 vecCentro = Vector2.right * radio;
                ang = Vector2.Angle(vecCentro, objectCollision.GetContact(0).point);

            }
        }

        if (!shield)
        {
            if (objectCollision.transform.tag == "Spike") //|| objectCollision.transform.tag == "Trojan" || objectCollision.transform.tag == "Bug" || objectCollision.transform.tag == "Malware")
                Dying();
        }

        if (objectCollision.transform.tag == "Platform")
            MoveCamAddPoin(-2,10);

        else if (objectCollision.transform.tag == "PlatformElect")
            MoveCamAddPoin(-1,20);

        else if (objectCollision.transform.tag == "PlatformSpike")
            MoveCamAddPoin(-1,30);
    }

    public void MoveCamAddPoin(int vel, int num)
    {
        velocidadRotacion = vel;
        CameraTarget.instance.moveCam = true;
        PlayerProfile.instace.AddScore(num);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!shield){
            if (collision.transform.tag == "Spike")
                Dying();
        }
    }

    void OnTriggerEnter2D(Collider2D objectCollider)
    {
        if (!shield){
            if (objectCollider.transform.tag == "Spike" || objectCollider.transform.tag == "DeadZone")
                Dying();   
        }

        if (objectCollider.transform.tag == "Gravity")
            Turn();
    }

    IEnumerator Dance()
    {
        dance = true;

        yield return new WaitForSeconds(10.0f);
        covyAnimator.SetTrigger("Dancing");
    }

    void ShieldOn()
    {
        StartCoroutine(TimeWait());

        InvokeRepeating("Shield", 0.1f, 1.0f);
    }

    IEnumerator TimeWait()
    {
        yield return new WaitForSeconds(1.0f);
        SFXManeger.instance.PlaySFX(SFXType.POWERUP_EQUIP);

    }

    void ShieldOff()
    {
        CancelInvoke("Shield");
        countShield = 0;
        shield = false;
    }

    void Shield()
    {
        countShield++;
    }
}
