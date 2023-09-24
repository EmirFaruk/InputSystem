using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "InputReader")]
public class InputReader : ScriptableObject, GameInput.IGameplayActions, GameInput.IUIActions
{
    #region Variables

    private GameInput gameInput;

    #endregion

    #region Disable/Enable

    private void OnDisable()
    {

    }

    private void OnEnable()
    {
        if (gameInput == null)
        {
            gameInput = new();

            gameInput.Gameplay.SetCallbacks(this);
            gameInput.UI.SetCallbacks(this);
        }

        SetGameplay();
    }

    #endregion


    #region Set Action Maps

    public void SetGameplay()
    {
        gameInput.Gameplay.Enable();
        gameInput.UI.Disable();
    }

    public void SetUI()
    {
        gameInput.Gameplay.Disable();
        gameInput.UI.Enable();
    }

    #endregion

    #region Action Maps Actions

    public event Action<Vector2> MoveEvent;

    public event Action JumpEvent;
    public event Action JumpCancelledEvent;

    public event Action PauseEvent;
    public event Action ResumeEvent;

    #endregion


    #region I_GameplyActions

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            JumpEvent?.Invoke();

        if (context.phase == InputActionPhase.Canceled)
            JumpCancelledEvent?.Invoke();
    }

    #endregion

    #region I_UIActions

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            PauseEvent?.Invoke();
            SetUI();
        }
    }

    public void OnResume(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            ResumeEvent?.Invoke();
            SetGameplay();
        }
    }
    #endregion
}
