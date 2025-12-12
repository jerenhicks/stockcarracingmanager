using UnityEngine;

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}

public class TimeController : MonoBehaviour
{
    public static TimeController Instance { get; private set; } = new TimeController();



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
