using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;

    private CinemachineVirtualCamera virtualCamera;

    private InputAction aimAction;

    [SerializeField]
    private int priorityAmount = 10;

    [SerializeField]
    private Canvas thirdPersonCanvas;

    [SerializeField]
    private Canvas aimCanvas;

    private void Awake()
    {

        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        aimAction = playerInput.actions["Aim"];
    }


    private void OnEnable()
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();
    }

    private void OnDisable()
    {
        aimAction.performed -= _ => StartAim();
        aimAction.canceled -= _ => CancelAim();
    }

    private void StartAim()
    {
        virtualCamera.Priority += priorityAmount;
        aimCanvas.enabled = true;
        thirdPersonCanvas.enabled = false;
    }

    private void CancelAim()
    {
        virtualCamera.Priority -= priorityAmount;
        aimCanvas.enabled = false;
        thirdPersonCanvas.enabled = true;
    }
}
