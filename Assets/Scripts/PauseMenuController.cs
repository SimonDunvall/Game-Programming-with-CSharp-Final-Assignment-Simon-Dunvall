using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuController : MonoBehaviour
{
    private static PauseMenuController instance;

    private void Initialize()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }

        Destroy(gameObject);
    }

    public InputActionAsset primaryActions;
    private InputActionMap pauseMenuActionMap;
    private InputAction pauseMenuInputAction;

    private void Awake()
    {
        Initialize();
        pauseMenuActionMap = primaryActions.FindActionMap("PauseMenu");

        pauseMenuInputAction = pauseMenuActionMap.FindAction("Pause Game");

        pauseMenuInputAction.performed += PauseGame;
    }

    private void OnEnable()
    {
        pauseMenuInputAction?.Enable();
    }

    private void OnDisable()
    {
        pauseMenuInputAction?.Disable();
    }

    private void PauseGame(InputAction.CallbackContext context)
    {
        Debug.Log("paused");
    }
}