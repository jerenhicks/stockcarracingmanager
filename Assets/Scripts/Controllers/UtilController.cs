using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class UtilController : MonoBehaviour
{
    public static UtilController Instance { get; private set; } = new UtilController();
    List<string> maleFirstNames = new List<string>();
    List<string> femaleFirstNames = new List<string>();
    List<string> lastNames = new List<string>();
    public List<Location> locations = new List<Location>();

    private static readonly string configsPath = Path.Combine(Application.dataPath, "Configs");
    private static readonly string maleFirstNamesPath = Path.Combine(configsPath, "male_names.txt");
    private static readonly string femaleFirstNamesPath = Path.Combine(configsPath, "female_names.txt");
    private static readonly string lastNamesPath = Path.Combine(configsPath, "last_names.txt");
    private static readonly string locationsPath = Path.Combine(configsPath, "locations.json");

    private void Awake()
    {
        // Ensure singleton instance
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        LoadNames();
        LoadLocations();
        DontDestroyOnLoad(gameObject);
    }

    private void LoadNames()
    {

        // Load male first names
        if (File.Exists(maleFirstNamesPath))
        {
            maleFirstNames = File.ReadAllLines(maleFirstNamesPath).ToList();
        }

        // Load female first names
        if (File.Exists(femaleFirstNamesPath))
        {
            femaleFirstNames = File.ReadAllLines(femaleFirstNamesPath).ToList();
        }

        // Load last names
        if (File.Exists(lastNamesPath))
        {
            lastNames = File.ReadAllLines(lastNamesPath).ToList();
        }
    }

    private void LoadLocations()
    {
        if (File.Exists(locationsPath))
        {
            string json = File.ReadAllText(locationsPath);
            locations = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Location>>(json);
        }
    }


    public string GetRandomMaleFirstName()
    {
        if (maleFirstNames.Count == 0) LoadNames();
        return maleFirstNames[Random.Range(0, maleFirstNames.Count)];
    }

    public string GetRandomFemaleFirstName()
    {
        if (femaleFirstNames.Count == 0) LoadNames();
        return femaleFirstNames[Random.Range(0, femaleFirstNames.Count)];
    }

    public string GetRandomLastName()
    {
        if (lastNames.Count == 0) LoadNames();
        return lastNames[Random.Range(0, lastNames.Count)];
    }

}