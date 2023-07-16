using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EscapeUI : MonoBehaviour
{
    [SerializeField]
    private GameObject escapeUI;

    public PlayerInputActions inputActions;

    private InputAction pause;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        pause = inputActions.Player.Pause;
        pause.Enable();
    }

    private void Update()
    {
        if (pause.triggered)
        {
            ToggleUI();
        }
    }

    public void ToggleUI()
    {
        escapeUI.SetActive(!escapeUI.activeSelf);
    }
}
