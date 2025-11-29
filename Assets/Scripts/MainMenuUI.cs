using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private string newGameSceneName = "TeamSetup";

    public void OnNewGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(newGameSceneName);
    }

    public void OnQuitGame()
    {
#if UNITY_EDITOR
        // Stop play mode in the editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Quit the standalone build
        Application.Quit();
#endif
    }

    public void OnLoadGame()
    {
        // Implement load game functionality here
        Debug.Log("Load Game button clicked - functionality not implemented yet.");
    }
}
