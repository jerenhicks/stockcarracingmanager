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
    public List<BusinessLocation> businessLLocations = new List<BusinessLocation>();
    public List<Track> tracks = new List<Track>();

    private static readonly string configsPath = Path.Combine(Application.dataPath, "Configs");
    private static readonly string maleFirstNamesPath = Path.Combine(configsPath, "male_names.txt");
    private static readonly string femaleFirstNamesPath = Path.Combine(configsPath, "female_names.txt");
    private static readonly string lastNamesPath = Path.Combine(configsPath, "last_names.txt");
    private static readonly string locationsPath = Path.Combine(configsPath, "locations.json");
    private static readonly string businessLocationsPath = Path.Combine(configsPath, "businesslocations.json");
    private static readonly string tracksPath = Path.Combine(configsPath, "tracks.json");

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
        LoadBusinessLocations();
        LoadTracks();
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
            // Assuming you have a LocationList wrapper class to deserialize a list of locations
            LocationList locationList = Newtonsoft.Json.JsonConvert.DeserializeObject<LocationList>(json);
            // Do something with locationList.locations if needed
        }
    }

    private void LoadBusinessLocations()
    {
        if (File.Exists(businessLocationsPath))
        {
            string json = File.ReadAllText(businessLocationsPath);
            businessLLocations = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BusinessLocation>>(json);
        }
    }

    private void LoadTracks()
    {
        if (File.Exists(tracksPath))
        {
            string json = File.ReadAllText(tracksPath);
            tracks = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Track>>(json);
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