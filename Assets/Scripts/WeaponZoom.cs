using Cinemachine;
using StarterAssets;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera fpsCamera;
    [SerializeField] FirstPersonController fpsController;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = .5f;


    bool zoomInToggle = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomInToggle == false)
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
        zoomInToggle = false;
        fpsCamera.m_Lens.FieldOfView = zoomedOutFOV;
        fpsController.RotationSpeed = zoomOutSensitivity;
    }

    private void ZoomIn()
    {
        zoomInToggle = true;
        fpsCamera.m_Lens.FieldOfView = zoomedInFOV;
        fpsController.RotationSpeed = zoomInSensitivity;
    }

    private void OnDisable()
    {
        ZoomOut();
    }
}
