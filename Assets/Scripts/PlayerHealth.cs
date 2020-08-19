using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
  [SerializeField] float hitPoints = 100;

  DeathHandler death;


  private void Start() 
  {
      death = GetComponent<DeathHandler>();   
  }

   public void TakeDamage(float damage)
   {
      hitPoints -= damage;
      if(hitPoints == 0)
      {
         death.HandleDeath();
      }
   }
}
