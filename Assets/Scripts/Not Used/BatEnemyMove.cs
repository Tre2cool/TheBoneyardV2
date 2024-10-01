using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BatEnemyMove : MonoBehaviour
{
    //[SerializeField] float moveSpeed = 1f;
    public float speed = 1.19f;
    Vector3 pointA;
    Vector3 pointB;
   Rigidbody2D myRigidbody;

   Animator myAnimator;

   public AIPath aIPath;


    void Start(){

        //myRigidbody = GetComponent<Rigidbody2D>();
        //myAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {

           //myRigidbody.velocity = new Vector2(moveSpeed,0f);

           if(aIPath.desiredVelocity.x >= 0.01f)
           {
            transform.localScale = new Vector3(1f,1f,1f); // Going right
           }
           else if(aIPath.desiredVelocity.x<= -0.01f) //Going Left, flip sprite
           {
                transform.localScale = new Vector3(-1f,1f,1f); 
           }

         /*   if(aIPath.desiredVelocity.x<= -0.01f)
           {
           transform.localScale = new Vector3(1f,1f,1f);  // Going left
           }
           else if(aIPath.desiredVelocity.x >= 0.01f) //Going right, flip sprite
           {
                transform.localScale = new Vector3(-1f,1f,1f);
           } */
    }
    

    /*void Attack()
    {
        
        //myRigidbody.velocity = new Vector2(moveSpeed,0f);
        myAnimator.SetBool("isAttack", true);
        Debug.Log("Attack Call");  
         
    }*/


   /* void OnTriggerExit2D(Collider2D other) {

        moveSpeed = -moveSpeed;
        FlipEnemyFacing();
        
    }

   void FlipEnemyFacing()
    {

        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(transform.position, transform.position, time);
        transform.localScale = new Vector2 (-(Mathf.Sign(myRigidbody.velocity.x)), 1f);
        Debug.Log("FlipEnemyFacing");  
    }*/

}
