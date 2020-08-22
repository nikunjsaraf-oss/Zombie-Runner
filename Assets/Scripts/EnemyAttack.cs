using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage = 50;
    [SerializeField] UnityEvent onAttack;

    PlayerHealth player;
    
    void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if(player == null) return;
        onAttack.Invoke();
        player.TakeDamage(damage);
        player.GetComponent<DamageDisplay>().ShowDamagedCanvas();
    }
}
