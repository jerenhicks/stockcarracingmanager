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
        SceneManager.LoadScene("BusinessScene");


        // ShowOnly(partnerPanel);
        // DialogController.Instance.StartDialog(new List<DialogEntry>
        // {
        //     new DialogEntry
        //     {
        //         speakerName = "Narrator",
        //         content = "Now, let's learn about your partner.",
        //         avatar = null
        //     }
        // });
    }

    public void GoToPartnerBackstory()
    {
        ShowOnly(partnerBackstoryPanel);
    }

    public void GoToPlayerBackstory()
    {
        ShowOnly(playerBackstoryPanel);
    }

    private void ShowOnly(GameObject panelToShow)
    {
        playerPanel.SetActive(panelToShow == playerPanel);
        partnerPanel.SetActive(panelToShow == partnerPanel);
        partnerBackstoryPanel.SetActive(panelToShow == partnerBackstoryPanel);
        playerBackstoryPanel.SetActive(panelToShow == playerBackstoryPanel);
    }
}
