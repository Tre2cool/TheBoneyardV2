using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask playerLayer;
 

    public bool PlayerDetected {get; internal set;}

    RaycastHit2D hit;
    RaycastHit2D playerHit;
    Rigidbody2D rb;

    Animator myAnimator;

    //public float attackRange = 3f;
    Transform player;

    public GameObject Player;

    public Transform groundCheck;

    public Transform playerCheck;

    public float speed = 2f;

    bool isFacingRight= true;

    void Start()
    {

        rb = GetComponent <Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        //player = GameObject.FindGameObjectWithTag("Player").transform;

    }

   

    void Update() {

        hit = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayer);

         playerHit= Physics2D.Raycast(playerCheck.position, -transform.up, 1f, playerLayer);

        PlayerDetected = playerHit ==true;
        if(PlayerDetected){
            Detect();
            //OnPlayerDetected?.Invoke(collider.gameObject);
        }
        else{
            ResetAnim();
        }
    }
   private void FixedUpdate()
    {

       if(hit.collider !=false){  
            //Debug.Log("Hitting boundry");
               
                if(isFacingRight){
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                     Debug.Log("Right");
            
                }
                else{
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                     Debug.Log("Left");

                }
        
            }
            else 
            {
                isFacingRight = !isFacingRight;

                transform.localScale = new Vector3(-transform.localScale.x, 1f,1f);
                //Debug.Log("Not hitting boundry");
            }

    }

       public void Detect()
        {

                //enemy.GetComponent<Bat>().TakeDamage();
                myAnimator.SetTrigger("Attack");
                 //FindObjectOfType<EnemyAttack>().Attack();
                
                 Debug.Log("Patrol Attack");
              
        } 

        public void ResetAnim(){
        myAnimator.ResetTrigger("Attack");
         //Debug.Log("Reset Hurt");
    }


}
