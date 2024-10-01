using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 25;
	[SerializeField] int currentHealth;
    [SerializeField] int minDmg = 1;
    [SerializeField] int maxDmg = 5;

    private CinemachineImpulseSource _myImpulseSource;

    Animator myAnimator;

     [SerializeField] float levelLoadDelay = 3f;

    private void Start() {
        currentHealth = maxHealth;
         _myImpulseSource = GetComponent<CinemachineImpulseSource>();
          myAnimator = GetComponent<Animator>();
    }

    public void TakeDamage(){
        
        int RandDamage = Random.Range(minDmg,maxDmg);
        
            TakeLife(RandDamage);   
    }

     void TakeLife(int damage){

        Debug.Log($"Damage amount:  {damage}");
        currentHealth -= damage;
        myAnimator.SetTrigger("Hit");
        Debug.Log($"Current Health:  {currentHealth}");


        if(currentHealth <= 0){
            Debug.Log("Bat dead");
            Destroy(gameObject);
           // StartCoroutine(EnemyDeathLoad());

        }
        
    }

       IEnumerator EnemyDeathLoad(){

        //myAnimator.SetTrigger("Dead");

         yield return new WaitForSecondsRealtime(levelLoadDelay);
         Destroy(gameObject);
        //FindObjectOfType<GameSession>().ResetGameSession();

    }
}
