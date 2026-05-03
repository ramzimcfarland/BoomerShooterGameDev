using UnityEngine;
using UnityEngine.SceneManagement;

// load first arena
public class MainMenuButton : MonoBehaviour
{
    public void OnStart()
    {
        SceneManager.LoadScene("Arena" + ArenaManager.currentArena);
    }
}
