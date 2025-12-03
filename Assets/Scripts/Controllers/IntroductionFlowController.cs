using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class IntroductionFlowController : MonoBehaviour
{
    public GameObject playerPanel;
    public GameObject partnerPanel;
    public GameObject partnerBackstoryPanel;
    public GameObject playerBackstoryPanel;


    private void Start()
    {
        ShowOnly(playerPanel);
        DialogController.Instance.StartDialog(new List<DialogEntry>
        {
            new DialogEntry
            {
                speakerName = "Narrator",
                content = "Welcome to the Stock Car Racing Manager!",
                avatar = null
            },
            new DialogEntry
            {
                speakerName = "Narrator",
                content = "Let's start by getting to know you.",
                avatar = null
            }
        });
    }

    public void GoToPartnerPanel()
    {
        //FIXME: this is done intentionally to work on other things. Load up things right now.
        //SceneManager.LoadScene("BusinessScene");
        // UtilController util = UtilController.Instance;
        // //list all the locations loaded
        // foreach (Location loc in util.locations)
        // {
        //     Debug.Log($"Location: {loc.city}, {loc.state} - {loc.description} ({loc.latitude}, {loc.longitude})");
        // }


        ShowOnly(partnerPanel);
        DialogController.Instance.StartDialog(new List<DialogEntry>
        {
            new DialogEntry
            {
                speakerName = "Narrator",
                content = "Now, let's learn about your partner.",
                avatar = null
            }
        });
    }

    public void GoToPartnerBackstory()
    {
        ShowOnly(partnerBackstoryPanel);
    }

    public void GoToPlayerBackstory()
    {
        ShowOnly(playerBackstoryPanel);
    }

    public void FinishIntroduction()
    {
        SceneManager.LoadScene("GarageScene");
    }

    private void ShowOnly(GameObject panelToShow)
    {
        playerPanel.SetActive(panelToShow == playerPanel);
        partnerPanel.SetActive(panelToShow == partnerPanel);
        partnerBackstoryPanel.SetActive(panelToShow == partnerBackstoryPanel);
        playerBackstoryPanel.SetActive(panelToShow == playerBackstoryPanel);
    }
}
