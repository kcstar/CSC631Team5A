using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] Camera firstPersonCamera;
    [SerializeField] Camera thirdPersonCamera;
    [SerializeField] Camera overheadCamera;

    // Call this function to disable FPS camera,
    // and enable overhead camera.
    public void ShowOverheadView()
    {
        firstPersonCamera.enabled = false;
        overheadCamera.enabled = true;
        thirdPersonCamera.enabled = false;
    }

    // Call this function to enable FPS camera,
    // and disable overhead camera.
    public void ShowFirstPersonView()
    {
        firstPersonCamera.enabled = true;
        overheadCamera.enabled = false;
        thirdPersonCamera.enabled = false;
    }

    // Call this function to enable TPS camera
    // and disable overhead camera.
    public void ShowThirdPersonView()
    {
        firstPersonCamera.enabled = false;
        overheadCamera.enabled = false;
        thirdPersonCamera.enabled = true;
    }

    // Call this function if using a single key
    // to toggle between cameras.
    public void ChangeView()
    {
        if (firstPersonCamera.enabled == true)
        {
            ShowOverheadView();
        }
        else if (thirdPersonCamera.enabled == true)
        {
            ShowFirstPersonView();
        }
        else
        {
            ShowThirdPersonView();
        }
    }
}
