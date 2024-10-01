using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public int attackDamage = 20;
     public int minDmg = 10;
    public int maxDmg = 15;
	//public int enragedAttackDamage = 40;

    public Transform attackPoint;
	//public Vector3 attackOffset;
	public float attackRange = 1f;

    public LayerMask attackMask;

      private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


      public void Attack(){

       
        int RandDamage = Random.Range(minDmg,maxDmg);

        Collider2D[] damage = Physics2D.OverlapCircleAll( attackPoint.position, attackRange, attackMask );

        for (int i = 0; i < damage.Length; i++){
            
           //Destroy( damage[i].gameObject );
           //FindObjectOfType<GameSession>().ResetGameSession();
           FindObjectOfType<GameSession>().TakeEnemyHit(RandDamage);
            Debug.Log($"Damage amount:  {RandDamage}");
            Debug.Log("Attack()");
        }
    
    }
}
