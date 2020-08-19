using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
  [SerializeField] float hitPoints = 200;

   public void TakeDamage(float damage)
   {
      hitPoints -= damage;
      if(hitPoints == 0)
      {
         Debug.Log("Dead");
      }
   }
}
