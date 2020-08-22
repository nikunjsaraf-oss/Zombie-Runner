using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
  [SerializeField] float hitPoints = 100;
  [SerializeField] HealthBar healthBar;

  DeathHandler death;


  private void Start() 
  {
      death = GetComponent<DeathHandler>(); 
      healthBar.SetMaxHealth(hitPoints);  
      Time.timeScale = 1;
  }

   public void TakeDamage(float damage)
   {
      hitPoints -= damage;
      healthBar.SetHealth(hitPoints);

      if(hitPoints == 0)
      {
         death.HandleDeath();
      }
   }
}
