using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance { set; get; }
    [SerializeField] private GameObject pausePanel = null;
    public bool IsPaused = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        // DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        pausePanel?.SetActive(false);
        IsPaused = false;
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Method called when the user enters a pause input
    /// </summary>
    public void OnPause(InputValue value)
    {
        if (value.isPressed)
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (IsPaused)
        {
            IsPaused = false;
            Time.timeScale = 1f;
        }
        else
        {
            IsPaused = true;
            Time.timeScale = 0f;
        }
        pausePanel?.SetActive(IsPaused);
    }

    public void Continue()
    {
        if (IsPaused)
        {
            TogglePause();
        }
    }
}
