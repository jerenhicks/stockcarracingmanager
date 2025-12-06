using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DialogController : MonoBehaviour
{
    public static DialogController Instance { get; private set; } = new DialogController();

    [Header("UI References")]
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private Image avatarImage;      // Avatar image
    [SerializeField] private TMP_Text contentText;   // ContentText TMP
    [Header("Dialog Entries")]
    [SerializeField] private List<DialogEntry> dialogEntries = new List<DialogEntry>();

    [Header("Events")]
    public UnityEvent onDialogueFinished;

    private int currentIndex = -1;

    private void Awake()
    {
        // Ensure singleton instance
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }

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
    }

    void Update()
    {
        if (dialogPanel == null || !dialogPanel.activeInHierarchy)
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

        if (avatarImage != null)
        {
            if (entry.avatar != null)
            {
                avatarImage.sprite = entry.avatar;
                avatarImage.gameObject.SetActive(true);
            }
            else
            {
                avatarImage.gameObject.SetActive(false);
            }
        }

        if (contentText != null)
        {
            contentText.text = entry.content;
        }
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        ShowNext();
    }
}
