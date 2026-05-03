// slight Claude AI help in writing this script
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIScreenManager : MonoBehaviour
{

    public static UIScreenManager Instance;

    // all of the screens
   [Header("Pause")]
   [SerializeField] private GameObject pausePanel;

   [Header("Death")]
   [SerializeField] private GameObject deathPanel;
   [Header("HUD Panel")]
   [SerializeField] private GameObject hudPanel;
   [Header("Arena Cleared")]
   [SerializeField] private GameObject arenaClearedPanel;
   [Header("Game Won")]
   [SerializeField] private GameObject gameWonPanel ;

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

        if (arenaClearedPanel != null)
        {
            arenaClearedPanel.SetActive(false);
        }

        if (gameWonPanel != null)
        {
            gameWonPanel.SetActive(false);
        }
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnBackToMenu()
    {
        Time.timeScale = 1f;
        GameState.pause(false);
        SceneManager.LoadScene(0);   
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

    public void HandleArenaCleared()
    {
        GameState.pause(true);
        Time.timeScale = 0f;
        if (arenaClearedPanel != null)
        {
            arenaClearedPanel.SetActive(true);
        }

        if (hudPanel != null)
        {
            hudPanel.SetActive(false);
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void OnNextArena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void HandleGameWin()
    {
        GameState.pause(true);
        Time.timeScale = 0f;
        if (gameWonPanel != null)
        {
            gameWonPanel.SetActive(true);
        }

        if (hudPanel != null)
        {
            hudPanel.SetActive(false);
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
