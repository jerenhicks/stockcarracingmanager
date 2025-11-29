using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TeamSetupUI : MonoBehaviour
{

    [Header("UI References")]
    public TMP_InputField companyNameInput;
    public TMP_Dropdown difficultyDropdown;
    public Image logoPreview;

    [Header("Logos")]
    public List<Sprite> availableLogos;
    private int currentLogoIndex = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        difficultyDropdown.ClearOptions();
        var options = new List<TMP_Dropdown.OptionData>
        {
                new TMP_Dropdown.OptionData("Easy"),
                new TMP_Dropdown.OptionData("Medium"),
                new TMP_Dropdown.OptionData("Hard")
            };
        difficultyDropdown.AddOptions(options);

        ShowLogo(currentLogoIndex);
    }

    private void ShowLogo(int index) {
        if (availableLogos == null || availableLogos.Count == 0) {
            logoPreview.sprite = null;
            logoPreview.enabled = false;
            return;
        }

        currentLogoIndex = Mathf.Clamp(index, 0, availableLogos.Count - 1);
        logoPreview.enabled = true;
        logoPreview.sprite = availableLogos[currentLogoIndex];
    }

    // Hook this to PrevLogoButton OnClick
    public void OnPrevLogo() {
        if (availableLogos == null || availableLogos.Count == 0) return;

        int newIndex = currentLogoIndex - 1;
        if (newIndex < 0) newIndex = availableLogos.Count - 1; // wrap around
        ShowLogo(newIndex);
    }

    // Hook this to NextLogoButton OnClick
    public void OnNextLogo() {
        if (availableLogos == null || availableLogos.Count == 0) return;

        int newIndex = (currentLogoIndex + 1) % availableLogos.Count;
        ShowLogo(newIndex);
    }


    // Hook this to StartButton OnClick
    public void OnStartGame() {
        if (GameSettings.Instance == null) {
            Debug.LogError("GameSettings singleton is missing!");
            return;
        }

        // Save player choices
        GameSettings.Instance.CompanyName = string.IsNullOrWhiteSpace(companyNameInput.text)
            ? "New Team"      // default if blank
            : companyNameInput.text;

        GameSettings.Instance.GameDifficulty = (Difficulty)difficultyDropdown.value;

        if (availableLogos != null && availableLogos.Count > 0) {
            GameSettings.Instance.SelectedLogo = availableLogos[currentLogoIndex];
        }

        // For now, just reload the same scene or go to a placeholder scene
        // You can change "Garage" later when you make that scene.
        // SceneManager.LoadScene("Garage");
        Debug.Log($"Team created: {GameSettings.Instance.CompanyName}, " +
                  $"Difficulty: {GameSettings.Instance.GameDifficulty}, " +
                  $"LogoIndex: {currentLogoIndex}");
    }
}
