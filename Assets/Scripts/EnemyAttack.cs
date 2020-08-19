using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage = 50;

    PlayerHealth player;
    
    void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if(player == null) return;
        player.TakeDamage(damage);
    }
}
