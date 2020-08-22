using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemyhealth : MonoBehaviour
{
   [SerializeField] float hitPoints = 100;
   [SerializeField] UnityEvent onDie;

   bool isDead = false;   


   public bool IsDead()
   {
      return isDead;
   }

   public void TakeDamage(float damage)
   {
      BroadcastMessage("DamageTaken");
      hitPoints -= damage;
      Debug.Log(hitPoints);
      if(hitPoints <= 0)
      {
         Die();
      }
   }

    private void Die()
    {
       if (isDead) return;
       onDie.Invoke();
       isDead = true;
       GetComponent<Animator>().SetTrigger("Die");
    }
}
