using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDisplay : MonoBehaviour
{
   [SerializeField] Canvas attackedCanvas = null;
   [SerializeField] float canvasTime = 0.3f;

   private void Start() 
   {
        attackedCanvas.enabled = false;    
   }

   public void ShowDamagedCanvas()
   {
       StartCoroutine(ShowSplatter());
   }

    IEnumerator ShowSplatter()
    {
        attackedCanvas.enabled = true;
        yield return new WaitForSeconds(canvasTime);
        attackedCanvas.enabled = false;
    }
}
