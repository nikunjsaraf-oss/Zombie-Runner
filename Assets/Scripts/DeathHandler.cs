using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverUI = null;

    private void Start() 
    {
        gameOverUI.enabled = false;    
    }

    public void HandleDeath()
    {
        gameOverUI.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<SwitchWeapon>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
}
