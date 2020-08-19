using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
   [SerializeField] float hitPoints = 100;

   public void TakeDamage(float damage)
   {
      BroadcastMessage("DamageTaken");
      hitPoints -= damage;
      Debug.Log(hitPoints);
      if(hitPoints <= 0)
      {
         Destroy(gameObject);
      }
   }
   
}
