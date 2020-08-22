using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera = null;
    [SerializeField] float range = 100;
    [SerializeField] float damage = 5f;
    [SerializeField] ParticleSystem muzzleFlash = null;
    [SerializeField] GameObject hitFX = null;
    [SerializeField] Ammo ammoSlot = null;
    [SerializeField] AmmoType ammoType ;
    [SerializeField] float delayBetweenShots = 0.5f;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] UnityEvent onShoot;
  
    bool canShoot = true;

    private void OnEnable() 
    {
        canShoot = true;
    }

    void Update()
    {
        DisplayAmmo();
        if(Input.GetButtonDown("Fire1") && canShoot)
        {
           StartCoroutine("Shoot");
        }
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetAmmoAmount(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        if(ammoSlot.GetAmmoAmount(ammoType) != 0)
        {
            PlayEffects();
            ProcessRaycast();
            ammoSlot.ReduceAmmo(ammoType);
        }
        
        yield return new WaitForSeconds(delayBetweenShots);
        canShoot = true;
    }

    private void PlayEffects()
    {
        muzzleFlash.Play();
        onShoot.Invoke();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            Enemyhealth target = hit.transform.GetComponent<Enemyhealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else return;
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact =  Instantiate(hitFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
