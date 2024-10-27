using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

/// <summary>
///     This class encapsulate all the input processing for a player using Unity's new input system
/// </summary>

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputController : MonoBehaviour
{
    private Camera _camera;
    public bool IsPaused { get; set; }
    protected bool IsLeftClicking { get; set; }
    protected bool IsRightClicking { get; set; }
    private PlayerInput playerInput;

    protected void Awake()
    {
        // #if UNITY_EDITOR
        //     Cursor.visible = true;
        //     Cursor.lockState = CursorLockMode.None;
        // #endif

        // #if UNITY_STANDALONE_WIN
        //     Cursor.visible = true;
        //     Cursor.lockState = CursorLockMode.Confined;
        // #endif

        // #if UNITY_ANDROID_STANDALONE
        //     Cursor.visible = false;
        //     Cursor.lockState = CursorLockMode.Confined;
        // #endif

        playerInput = GetComponent<PlayerInput>();

        PlayerInputActions playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Move.performed += OnMove;
        playerInputActions.Player.LeftClick.performed += OnLeftClick;
        playerInputActions.Player.LeftClick.canceled += OnLeftClick;
        playerInputActions.Player.RightClick.canceled += OnRightClick;
        _camera = Camera.main;
    }

    #region Methods called by unity input events

    /// <summary>
    ///     Method called when the user enter a look input
    /// </summary>
    /// <param name="value"> The value of the input </param>
    public void OnMove(InputAction.CallbackContext context)
    {
        // Debug.Log("Moving: " + value.Get<Vector2>());
        
        Vector2 move = context.ReadValue<Vector2>();
        onMoveEvent.Invoke(move);
    }

    /// <summary>
    ///     Method called when the user enter a fire input
    /// </summary>
    /// <param name="value"> The value of the input </param>
    public void OnRightClick(InputAction.CallbackContext context)
    {
        IsRightClicking = context.performed;
        if (context.performed)
        {
            // onRightClickEvent.Invoke(IsRightClicking);
        } else if (context.canceled)
        {
            onRightClickEvent.Invoke(IsRightClicking);
        }
    }

    /// <summary>
    ///     Method called when the user enter a dash input
    /// </summary>
    /// <param name="value"> The value of the input </param>
    public void OnLeftClick(InputAction.CallbackContext context)
    {
        IsLeftClicking = context.canceled;
        if (context.performed)
        {
            // Debug.Log("Left click invoke");
            // Debug.Log(IsLeftClicking);
            onLeftClickEvent.Invoke(true);
        } else if (context.canceled)
        {
            onLeftClickEvent.Invoke(IsLeftClicking);
            // Debug.Log("Left click canceled");
            // Debug.Log(!IsLeftClicking);
            onLeftClickEvent.Invoke(false);
        }
    }

    #endregion

    #region Events

    private readonly MoveEvent onMoveEvent = new MoveEvent();
    private readonly LeftClickEvent onLeftClickEvent = new LeftClickEvent();
    private readonly RightClickEvent onRightClickEvent = new RightClickEvent();

    public UnityEvent<Vector2> OnMoveEvent => onMoveEvent;
    public UnityEvent<bool> OnLeftClickEvent => onLeftClickEvent;
    public UnityEvent<bool> OnRightClickEvent => onRightClickEvent;

    #endregion
}