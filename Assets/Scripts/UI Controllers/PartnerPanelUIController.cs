using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;

public class PartnerPanelUIController : MonoBehaviour
{
    [SerializeField] private GameObject avatar;
    [SerializeField] private TMP_InputField firstNameInput;
    [SerializeField] private TMP_InputField lastNameInput;

    private List<string> pngFileNames = new List<string>();
    private int currentAvatarIndex = 0;

    private void Awake()
    {
        // Load all .png file names from Assets/Resources/partner-avatars
        string avatarsPath = Path.Combine(Application.dataPath, "Resources/partner-avatars");
        if (Directory.Exists(avatarsPath))
        {
            pngFileNames = Directory.GetFiles(avatarsPath, "*.png").Select(Path.GetFileName).ToList();
        }
        UpdateAvatarImage();
    }

    private void UpdateAvatarImage()
    {
        if (pngFileNames.Count == 0) return;

        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pngFileNames[currentAvatarIndex]);
        Sprite newSprite = Resources.Load<Sprite>("partner-avatars/" + fileNameWithoutExtension);
        if (newSprite != null && avatar != null)
        {
            SpriteRenderer spriteRenderer = avatar.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = newSprite;
            }

            UnityEngine.UI.Image imageComponent = avatar.GetComponent<UnityEngine.UI.Image>();
            if (imageComponent != null)
            {
                imageComponent.sprite = newSprite;
            }
        }
    }

    public void ImageMoveLeft()
    {
        if (pngFileNames.Count == 0) return;

        currentAvatarIndex = (currentAvatarIndex - 1 + pngFileNames.Count) % pngFileNames.Count;
        UpdateAvatarImage();
    }

    public void ImageMoveRight()
    {
        if (pngFileNames.Count == 0) return;

        currentAvatarIndex = (currentAvatarIndex + 1) % pngFileNames.Count;
        UpdateAvatarImage();
    }

    public void OnNextClicked()
    {
        var gs = GameController.Instance;
        gs.partner.avatarFileName = pngFileNames[currentAvatarIndex];
        gs.partner.firstName = firstNameInput.text;
        gs.partner.lastName = lastNameInput.text;
        //FIXME: set pronouns later
        gs.partner.pronouns = Pronouns.SheHer;

        GetComponentInParent<IntroductionFlowController>().FinishIntroduction();
    }

}
