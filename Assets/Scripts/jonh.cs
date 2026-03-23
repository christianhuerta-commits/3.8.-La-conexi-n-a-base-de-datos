using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    // --- Variables de Componentes ---
    private Rigidbody2D Rigidbody2D;  
     private Animator Animator;
    private float Horizontal;// Controla las animaciones (correr, saltar, etc.)
    public GameObject BulletPrefab;
public float Speed;
public float JumpForce;
private bool Grounded;

private float LastShoot;
    void Start()
    {
        // Se obtienen las referencias a los componentes al iniciar
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator=GetComponent<Animator>();
    }

    void Update()
    {
       // Obtiene la entrada del teclado (Izquierda/Derecha)
        Horizontal = Input.GetAxisRaw("Horizontal");
// Voltea el sprite dependiendo de la dirección del movimiento 3.6. El movimiento de una bala
if(Horizontal<0.0f) transform.localScale= new Vector3(-1.0f,1.0f,1.0f);
else if (Horizontal>0.0f) transform.localScale=new Vector3(1.0f,1.0f,1.0f);

      // animacion de correr 3.6. El movimiento de una bala
        Animator.SetBool("running",Horizontal !=0.0f);
        Debug.DrawRay(transform.position,Vector3.down * 0.1f, Color.red);
       
       if(Physics2D.Raycast(transform.position,Vector3.down,0.1f))
        {
            Grounded=true;
        } else 
        Grounded=false;
       // Salto: Si presiona W y está en el suelo
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }
        if(Input.GetKey(KeyCode.Space) && Time.time>LastShoot + 0.25f)
        {
            Shoot();
            LastShoot=Time.time;
        }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up*JumpForce);
    }

    private void Shoot()

    {
        Vector3 direction;
        if(transform.localScale.x == 1.0f) direction=Vector2.right;
        else direction=Vector2.left;
       GameObject Bullet = Instantiate (BulletPrefab,transform.position + direction * 0.1f,Quaternion.identity);
       Bullet.GetComponent<BulletScript>().SetDirection(direction);
    }
    private void FixedUpdate()
    {
       
        Rigidbody2D.linearVelocity = new Vector2(Horizontal , Rigidbody2D.linearVelocity.y);
    }
}