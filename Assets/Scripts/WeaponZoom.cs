using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera FPSCamera = null;
    [SerializeField] float zoomedOutFOV = 40;
    [SerializeField] float zoomedInFOV = 20;
    [SerializeField] float zoomOutSensitivity = 2;
    [SerializeField] float zoomInSensitivity = 0.5f;
    [SerializeField] RigidbodyFirstPersonController FPSController = null;
    

    bool isZoomed = false;

    private void OnDisable() 
    {
        ZoomOut();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))    
        {
            if(isZoomed == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
        
    }

    private void ZoomOut()
    {
        FPSCamera.fieldOfView = zoomedOutFOV;
        FPSController.mouseLook.XSensitivity = zoomOutSensitivity;
        FPSController.mouseLook.YSensitivity = zoomOutSensitivity;
        isZoomed = false;
    }

    private void ZoomIn()
    {
        FPSCamera.fieldOfView = zoomedInFOV;
        FPSController.mouseLook.XSensitivity = zoomInSensitivity;
        FPSController.mouseLook.YSensitivity = zoomInSensitivity;
        isZoomed = true;
    }
}
