using UnityEngine;

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; } = new GameController();

    [Header("Player Choices")]
    public string CompanyName => player.businessName;
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
