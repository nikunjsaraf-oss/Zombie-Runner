using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverUI;

    private void Start() 
    {
        gameOverUI.enabled = false;    
    }

    public void HandleDeath()
    {
        gameOverUI.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
}
