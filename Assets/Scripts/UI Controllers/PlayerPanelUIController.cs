using UnityEngine;
using TMPro;

public class PlayerPanelUI : MonoBehaviour
{
    [Header("Input Fields")]
    [SerializeField] private TMP_InputField firstNameInput;
    [SerializeField] private TMP_InputField lastNameInput;
    [SerializeField] private TMP_InputField businessNameInput;

    private string selectedPronouns = "He / Him"; // default

    // Called by the pronoun buttons
    public void SetPronouns(string pronouns)
    {
        selectedPronouns = pronouns;
        // TODO: optionally update button visuals (highlight selected)
    }

    // Called by the Next button
    public void OnNextClicked()
    {
        var gs = GameController.Instance;

        gs.player.firstName = firstNameInput.text;
        gs.player.lastName = lastNameInput.text;
        gs.player.businessName = businessNameInput.text;
        //FIXME: set pronouns properly
        gs.player.pronouns = Pronouns.HeHim;


        Debug.Log($"Player Info: {gs.player.firstName} {gs.player.lastName}, Pronouns: {gs.player.pronouns}, Business Name: {gs.player.businessName}");


        GetComponentInParent<IntroductionFlowController>().GoToPartnerPanel();
    }
}
