using UnityEngine;
using UnityEngine.InputSystem;

public class UIScreenManager : MonoBehaviour
{

    public static UIScreenManager Instance;

   [Header("Pause")]
   [SerializeField] private GameObject pausePanel;

   [Header("Death")]
   [SerializeField] private GameObject deathPanel;
   [Header("HUD Panel")]
   [SerializeField] private GameObject hudPanel;

//    [Header("Win")]
//    [SerializeField] private GameObject winPanel;
// private bool hasWon = false;

    private void Awake()
    {
        Instance = this;

        GameState.pause(false);

        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }

        if (deathPanel != null)
        {
            deathPanel.SetActive(false);
        }

        if (hudPanel != null)
        {
            hudPanel.SetActive(true);
        }

        // if (winPanel != null)
        // {
        //     winPanel.SetActive(false);
        // }
    }
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        if (GameState.IsGamePaused())
        {
            GameState.pause(false);
            Time.timeScale = 1f;
            if (pausePanel != null)
            {
                pausePanel.SetActive(false);
            }

            //lock cursor again when resuming
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            GameState.pause(true);
            Time.timeScale = 0f;
            if (pausePanel != null)
            {
                pausePanel.SetActive(true);
            }

            //unlock cursor when on pause
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }

    public void OnRestart()
    {
        Time.timeScale = 1f;
        GameState.pause(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void OnBackToMenu()
    {
        Time.timeScale = 1f;
        GameState.pause(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);   
    }

    public void HandlePlayerDeath()
    {
        GameState.pause(true);
        Time.timeScale = 0f;
        if (deathPanel != null)
        {
            deathPanel.SetActive(true);
        }

        if (hudPanel != null)
        {
            hudPanel.SetActive(false);
        }

        //unlock cursor when on death screen
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
