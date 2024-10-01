using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;
using Unity.VisualScripting;

public class EnemyAIGround : MonoBehaviour
{
    [Header("Pathfinding")]
    public Transform target;
    public float activateDistance = 50f;
    public float pathUpdateSeconds = 0.5f;

    [Header("Physics")]
    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    public float jumpNodeHeightRequirement = 0.8f;
    public float jumpModifier = 0.3f;

    public float jumpCheckOffset = 0.1f;

    [Header("Custom Behavoir")]

    public bool followEnabled = true;
    public bool jumpEnabled = true;
    public bool directionLookEnabled = true;
    [SerializeField] LayerMask groundLayer;

    public Transform groundCheck;

    RaycastHit2D hit;

    private Path path;
    private int currentWaypoint = 0;
    bool isGrounded = false;
    Seeker seeker;
    Rigidbody2D rb;
    Animator myAnimator;
    Collider2D coll;

    
    
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent <Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
          coll = GetComponent<Collider2D>();

        InvokeRepeating("UpdatePath",0f, pathUpdateSeconds);
    }

    void Update() {

        hit = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayer);
        
    }
   private void FixedUpdate()
    {
       if(TargetInDistance() && followEnabled){

        PathFollow();


       }

      /* if(hit.collider !=false){
        Debug.Log("Hitting ground");
       }else
       {
        Debug.Log("Not hitting ground");
       }*/

       /* if(hit.collider !=false){  
            Debug.Log("Hitting boundry");
            if(isFacingLeft){
            
                 followEnabled = true;

            }
            else{
                  

            }
        
            }
            else 
            {
                followEnabled = false;
                transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                Debug.Log("Not hitting boundry");
            }*/

       
    }

    void UpdatePath()
    {
         if( followEnabled && TargetInDistance() && seeker.IsDone()){
             seeker.StartPath(rb.position,target.position,OnPathComplete);
        }
    }


    private void PathFollow(){

        if(path == null){
            return;
        }

        //  Reach end of path
        if(currentWaypoint >= path.vectorPath.Count){
            
            return;

        }


        //See if colliding with anything
        Vector3 startOffset = transform.position - new Vector3(0f, GetComponent<Collider2D>().bounds.extents.y + jumpCheckOffset, transform.position.z);
        isGrounded = Physics2D.Raycast(startOffset, -Vector3.up, 0.05f); 
        //isGrounded = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        //RaycastHit2D isGrounded = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        //RaycastHit2D isGrounded = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayer);
         //hit = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayer);
        
        //Directon Calculation
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint]- rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        if(jumpEnabled && isGrounded){

            if(direction.y > jumpNodeHeightRequirement){
                rb.AddForce(Vector2.up * speed * jumpModifier);
            }

        }

        //Movement
         rb.AddForce(force);
         //rb.velocity = new Vector2(force.x, rb.velocity.y);



        // Next Waypoint
        float distance = Vector2.Distance(rb.position,path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance){

            currentWaypoint++;
        }

        // Direction Graphics Handling

        if(directionLookEnabled){

         if(rb.velocity.x >= 0.05f)
           {
                transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                
           }
           else if(rb.velocity.x <= -0.05f) 
           {
                
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                
           }
        }

    }

    private bool TargetInDistance(){

        return Vector2.Distance(transform.position,target.transform.position) < activateDistance;
        
    }

     void OnPathComplete(Path p){

        if(!p.error){
            path = p;
            currentWaypoint = 0;
        }

    }

}
