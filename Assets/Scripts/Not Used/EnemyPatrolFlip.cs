using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyPatrolFlip : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask playerLayer;
    public LayerMask targetLayer;

    //public UnityEvent<GameObject>OnPlayerDetected;

    [Range(.1f,1)]
    public float radius;

    [Header("Gizmo Parameters")]
    public Color gizmoColor = Color.green;
    public bool showGizmos = true;

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

    //public Transform playerCheck;

    public float speed = 2f;

    bool isFacingRight= true;

     public bool flip;





    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent <Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        hit = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayer);

        //var collider = Physics2D.OverlapCircle(transform.position, radius, targetLayer);

        playerHit= Physics2D.Raycast(playerCheck.position, -transform.up, 1f, playerLayer);

        PlayerDetected = playerHit ==true;
        if(PlayerDetected){
            Detect();
            //OnPlayerDetected?.Invoke(collider.gameObject);
        }

       // Vector3 scale = transform.localScale;

         /*if (Player.transform.position.x > transform.position.x){
            //right
            scale.x = Mathf.Abs(scale.x) * (flip ? -1: 1);
            //transform.Translate(speed * Time.deltaTime, 0, 0);
            
            //transform.Translate(speed * Time.deltaTime * -1, 0 ,0);
         }
         else{
            //Left
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1: 1);
           // transform.Translate(speed * Time.deltaTime, 0, 0);
           
           //transform.Translate(speed * Time.deltaTime * -1, 0 ,0);
         }*/

         //transform.localScale = scale;

       
    }

    private void FixedUpdate()
    {

       if(hit.collider !=false){  
           // Debug.Log("Not hitting boundry");

                Vector3 scale = transform.localScale;
               
                if(isFacingRight){
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                    Debug.Log("Right");

            
                }
                else{
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                    Debug.Log("Left");

                }

                //Detect();
        
            }
            else 
            {
                isFacingRight = !isFacingRight;

                transform.localScale = new Vector3(-transform.localScale.x, 1f,1f);
                //Debug.Log("Hitting boundry");
            }

           /* Vector3 scale = transform.localScale;

         if (Player.transform.position.x > transform.position.x){
            //right
            scale.x = Mathf.Abs(scale.x) * (flip ? -1: 1);
            //transform.Translate(speed * Time.deltaTime, 0, 0);
            
            //transform.Translate(speed * Time.deltaTime * -1, 0 ,0);
         }
         else{
            //Left
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1: 1);
           // transform.Translate(speed * Time.deltaTime, 0, 0);
           
           //transform.Translate(speed * Time.deltaTime * -1, 0 ,0);
         }

         transform.localScale = scale;*/



    }


     public void Detect()
        {
          
                 Debug.Log("Patrol Attack");
              
        } 
        
    private void OnDrawGizmos()
    {
        if(showGizmos){
            Gizmos.color = gizmoColor;
            Gizmos.DrawSphere(transform.position, radius);
        }
    }

}
