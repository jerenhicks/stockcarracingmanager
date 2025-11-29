using UnityEngine;

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance { get; private set; } = new GameSettings();

    [Header("Player Choices")]
    public string CompanyName;
    public Difficulty GameDifficulty;
    public Sprite SelectedLogo;

    public Player player = new Player();
    public Partner partner = new Partner();

    private void Awake()
    {
        // Ensure singleton instance
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
