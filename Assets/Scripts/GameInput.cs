using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{


    private const string PlayerPrefsBindings = "InputBindings";
    
    public static GameInput Instance { get; private set; }
    
    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;
    public event EventHandler OnPauseAction;
    public event EventHandler OnBindingRebind;

    public enum Binding
    {
        MoveUp,
        MoveDown,
        MoveLeft,
        MoveRight,
        Interact,
        InteractAlt,
        Pause,
        GamepadInteract,
        GamepadInteractAlt,
        GamepadPause
    }
    
    private PlayerInputActions playerInputActions;
    
    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputActions();
        
        if (PlayerPrefs.HasKey(PlayerPrefsBindings))
        {
            playerInputActions.LoadBindingOverridesFromJson(PlayerPrefs.GetString(PlayerPrefsBindings));
        }
        
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
        playerInputActions.Player.InteractAlternate.performed += InteractAlternate_performed;
        playerInputActions.Player.Pause.performed += Pause_performed;
    }

    private void OnDestroy()
    {
        playerInputActions.Player.Interact.performed -= Interact_performed;
        playerInputActions.Player.InteractAlternate.performed -= InteractAlternate_performed;
        playerInputActions.Player.Pause.performed -= Pause_performed;
        
        playerInputActions.Dispose();
    }

    private void Pause_performed(InputAction.CallbackContext obj)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }
    
    private void InteractAlternate_performed(InputAction.CallbackContext obj)
    {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }
    
    public Vector2 GetMovementVectorNormalized()
    {
        var inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        return inputVector;
    }

    public string GetBindingText(Binding binding)
    {
        switch (binding)
        {
            default:
            case Binding.Interact:
                return playerInputActions.Player.Interact.bindings[0].ToDisplayString();
            case Binding.InteractAlt:
                return playerInputActions.Player.InteractAlternate.bindings[0].ToDisplayString();
            case Binding.Pause:
                return playerInputActions.Player.Pause.bindings[0].ToDisplayString();
            case Binding.MoveUp:
                return playerInputActions.Player.Move.bindings[1].ToDisplayString();
            case Binding.MoveDown:
                return playerInputActions.Player.Move.bindings[2].ToDisplayString();
            case Binding.MoveLeft:
                return playerInputActions.Player.Move.bindings[3].ToDisplayString();
            case Binding.MoveRight:
                return playerInputActions.Player.Move.bindings[4].ToDisplayString();
            case Binding.GamepadInteract:
                return playerInputActions.Player.Interact.bindings[1].ToDisplayString();
            case Binding.GamepadInteractAlt:
                return playerInputActions.Player.InteractAlternate.bindings[1].ToDisplayString();
            case Binding.GamepadPause:
                return playerInputActions.Player.Pause.bindings[1].ToDisplayString();
        }
    }

    public void RebindBinding(Binding binding, Action onActionRebound)
    {
        playerInputActions.Player.Disable();

        InputAction inputAction;
        int bindingIndex;
        
        switch (binding)
        {
            default:
            case Binding.MoveUp:
                inputAction = playerInputActions.Player.Move;
                bindingIndex = 1;
                break;
            case Binding.MoveDown:
                inputAction = playerInputActions.Player.Move;
                bindingIndex = 2;
                break;
            case Binding.MoveLeft:
                inputAction = playerInputActions.Player.Move;
                bindingIndex = 3;
                break;
            case Binding.MoveRight:
                inputAction = playerInputActions.Player.Move;
                bindingIndex = 4;
                break;
            case Binding.Interact:
                inputAction = playerInputActions.Player.Interact;
                bindingIndex = 0;
                break;
            case Binding.InteractAlt:
                inputAction = playerInputActions.Player.InteractAlternate;
                bindingIndex = 0;
                break;
            case Binding.Pause:
                inputAction = playerInputActions.Player.Pause;
                bindingIndex = 0;
                break;
            case Binding.GamepadInteract:
                inputAction = playerInputActions.Player.Interact;
                bindingIndex = 1;
                break;
            case Binding.GamepadInteractAlt:
                inputAction = playerInputActions.Player.InteractAlternate;
                bindingIndex = 1;
                break;
            case Binding.GamepadPause:
                inputAction = playerInputActions.Player.Pause;
                bindingIndex = 1;
                break;
        }

        inputAction.PerformInteractiveRebinding(bindingIndex)
            .OnComplete(callback =>
            {
                callback.Dispose();
                playerInputActions.Player.Enable();
                onActionRebound();
                
                PlayerPrefs.SetString(PlayerPrefsBindings, playerInputActions.SaveBindingOverridesAsJson());
                PlayerPrefs.Save();
                
                OnBindingRebind?.Invoke(this, EventArgs.Empty);
            })
            .Start();
    }
    
}
