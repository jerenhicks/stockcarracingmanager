using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DialogueUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private Image avatarImage;      // Avatar image
    [SerializeField] private TMP_Text contentText;   // ContentText TMP
    [Header("Dialog Entries")]
    [SerializeField] private List<DialogEntry> dialogEntries = new List<DialogEntry>();

    [Header("Events")]
    public UnityEvent onDialogueFinished;

    private int currentIndex = -1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Optional: start immediately if you’ve filled dialogEntries in Inspector
        if (dialogEntries.Count > 0)
        {
            StartDialog(dialogEntries);
        }
        else
        {
            dialogPanel.SetActive(false);
        }

        //TEST CODE
        StartDialog(new List<DialogEntry>
        {
            new DialogEntry
            {
                dialogMessage = "Welcome to the game!",
                avatarImage = null // Assign a default avatar if needed
            },
            new DialogEntry
            {
                dialogMessage = "This is a sample dialogue.",
                avatarImage = null
            }
        });
    }

    void Update()
    {
        if (!dialogPanel.activeSelf)
            return;

        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            ShowNext();
        }
    }

    public void StartDialog(List<DialogEntry> entries)
    {
        if (entries == null || entries.Count == 0)
        {
            dialogPanel.SetActive(false);
            return;
        }

        dialogEntries = entries;
        currentIndex = -1;
        dialogPanel.SetActive(true);
        ShowNext();
    }


    public void ShowNext()
    {
        currentIndex++;

        if (currentIndex >= dialogEntries.Count)
        {
            // Finished
            dialogPanel.SetActive(false);
            onDialogueFinished?.Invoke();
            return;
        }

        DialogEntry entry = dialogEntries[currentIndex];

        if (avatarImage != null && entry.avatarImage != null)
        {
            avatarImage.sprite = entry.avatarImage;
        }

        if (contentText != null)
        {
            contentText.text = entry.dialogMessage;
        }
    }

    // This is called whenever the user clicks anywhere on ChatPanel
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("DialogueUI clicked, showing next dialog entry.");
        ShowNext();
    }
}
