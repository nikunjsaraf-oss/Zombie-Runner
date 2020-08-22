using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
   [SerializeField] static bool isPaused = false;
   [SerializeField] GameObject pauseMenuUI = null;

   private void Update() {
       if(Input.GetKeyDown(KeyCode.Escape))
       {
           if(isPaused)
           {
               Resume();
           }
           else
           {
               Pause();
           }
       }
   }

    private void Resume()
    {
        FindObjectOfType<SwitchWeapon>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    private void Pause()
    {
        FindObjectOfType<SwitchWeapon>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }
}
