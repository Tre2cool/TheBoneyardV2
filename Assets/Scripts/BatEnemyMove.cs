using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEnemyMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    public float speed = 1.19f;
    Vector3 pointA;
    Vector3 pointB;
   Rigidbody2D myRigidbody;

   Animator myAnimator;


    void Start(){

        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {

           myRigidbody.velocity = new Vector2(moveSpeed,0f);
    }
    

    /*void Attack()
    {
        
        //myRigidbody.velocity = new Vector2(moveSpeed,0f);
        myAnimator.SetBool("isAttack", true);
        Debug.Log("Attack Call");  
         
    }*/


    void OnTriggerExit2D(Collider2D other) {

        moveSpeed = -moveSpeed;
        FlipEnemyFacing();
        
    }

   void FlipEnemyFacing()
    {

        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(transform.position, transform.position, time);
        transform.localScale = new Vector2 (-(Mathf.Sign(myRigidbody.velocity.x)), 1f);
        Debug.Log("FlipEnemyFacing");  
    }

}
