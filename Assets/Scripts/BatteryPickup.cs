using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float increasedAngle = 70;
    [SerializeField] float increasedIntensity = 1;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponentInChildren<FlashLight>().RestoreLightAngle(increasedAngle);
            other.gameObject.GetComponentInChildren<FlashLight>().AddLightIntensity(increasedIntensity);
            Destroy(gameObject);
        }
    }
}
