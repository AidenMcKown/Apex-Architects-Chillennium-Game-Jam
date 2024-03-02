using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [Header("Script References")]
    public static PlayerControls PlayerControls;
    public static event Action<InputActionMap> ActionMapChange;

    [Header("Game Input Variables")]
    [HideInInspector] public static Vector2 MovementInput;
    [HideInInspector] public static bool SprintInput;
    [HideInInspector] public static bool JumpInput;
    [HideInInspector] public static bool GameEscapeInput;

    [Header("Menu Input Variables")]
    [HideInInspector] public static bool UIEscapeInput;
    public static bool HasGameStarted;

    void Awake()
    {
        PlayerControls = new PlayerControls();
    }

    void Update()
    {
        // Storing input in variables (player action map)
        MovementInput = PlayerControls.Player.Movement.ReadValue<Vector2>();
        SprintInput = PlayerControls.Player.SprintToggle.IsPressed();
        JumpInput = PlayerControls.Player.Jump.triggered;

        // Enter pause menu
        GameEscapeInput = PlayerControls.Player.Escape.triggered;
        if (GameEscapeInput && EnvironmentEventManager.IsGameActive && HasGameStarted)
        {
            EnvironmentEventManager.IsGameActive = false;
            SwitchActionMap(PlayerControls.UI);
        }

        // Exit pause menu
        UIEscapeInput = PlayerControls.UI.Escape.triggered;
        if (UIEscapeInput && !EnvironmentEventManager.IsGameActive && HasGameStarted)
        {
            EnvironmentEventManager.IsGameActive = true;
            SwitchActionMap(PlayerControls.Player);
        }
    }

    void OnEnable()
    {
        // Only turn on the UI action map at start because player has not started the game yet
        PlayerControls.UI.Enable();
        HasGameStarted = false;
    }

    void OnDisable()
    {
        PlayerControls.Disable();
    }

    public static void SwitchActionMap(InputActionMap actionMap)
    {
        // If the desired action map is already enabled then return
        if (actionMap.enabled) return;

        Debug.Log("Switching action map to " + actionMap.name);

        // Disables every action map
        PlayerControls.Disable();
        // Call the action map change event so scripts are aware of the change (optional)
        ActionMapChange?.Invoke(actionMap);
        // Enable desired action map
        actionMap.Enable();
    }
}
