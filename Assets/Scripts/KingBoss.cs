using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class KingBoss : MonoBehaviour
{
    public Transform player;

    public bool isFlipped = false;

    public int maxHealth = 200;
	public int currentHealth;

	public HealthBar healthBar;

    private CinemachineImpulseSource _myImpulseSource;

    Animator myAnimator;

     [SerializeField] float levelLoadDelay = 3f;

    private void Start() {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
         _myImpulseSource = GetComponent<CinemachineImpulseSource>();
          myAnimator = GetComponent<Animator>();
    }

   /* void Update(){
        if(Input.GetKeyDown(KeyCode.I)){
            TakeDamage(20);
        }
    }*/

    public void LookAtPlayer(){

        Vector3 flipped =transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x > player.position.x && isFlipped){

            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;

        }
        else if(transform.position.x < player.position.x && !isFlipped){

            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;


        }
    }

    public void TakeDamage(){
        
        if(currentHealth > 1){
            TakeLife(20);
        }
        else{

            currentHealth = 0;
            Debug.Log("King dead");
            StartCoroutine(KindDeathLoad());
        }
      
    }

     void TakeLife(int damage){


        myAnimator.SetTrigger("Hit");

        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
        
        
    }

       IEnumerator KindDeathLoad(){

        myAnimator.SetTrigger("Dead");

         yield return new WaitForSecondsRealtime(levelLoadDelay);
        FindObjectOfType<GameSession>().ResetGameSession();

    }
}
