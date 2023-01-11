using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    // Variables
    private GameManager gameManager;
    private TextMeshProUGUI text;
    private TextMeshProUGUI pageCounter;
    private Image image;
    private Button nextButton;
    private Button previousButton;
    private Button closeButton;
    public GameObject girl;

    
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        text = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        pageCounter = transform.Find("Pages/PageBackground/PageCounter").GetComponent<TextMeshProUGUI>();
        image = transform.Find("FaceBackground/Face").GetComponent<Image>();
        nextButton = transform.Find("Pages/NextPageButton").GetComponent<Button>();
        previousButton = transform.Find("Pages/PreviousPageButton").GetComponent<Button>();
        closeButton = transform.Find("CloseButton").GetComponent<Button>();

        nextButton.onClick.AddListener(CloseDialog);
        closeButton.onClick.AddListener(CloseDialog);

    }

    public void StartDialog(Quest quest)
    {
        quest.ResetQuest();
        SetDialog(quest);
    }


    public void SetDialog(Quest quest)
    {
        nextButton.onClick.RemoveAllListeners();
        if (quest.IsLastDialog())
        {
            nextButton.onClick.AddListener(CloseDialog);

            // Change game manager current quest
            gameManager.currentQuest = quest;

            // if is girl quest, hide girl
            if (quest.objective == "Encontrar um lugar seguro.")
            {
                // Find gameobject girl and hide it
                girl.SetActive(false);
            }
        }
        else
        {
            nextButton.onClick.AddListener(() =>
            {
                GoNextPageDialog(quest);
            });
        }

        if (!quest.IsFirstDialog())
        {
            previousButton.interactable = true;
            previousButton.onClick.RemoveAllListeners();
            previousButton.onClick.AddListener(() =>
            {
                GoPreviousPageDialog(quest);
            });
        }
        else
            previousButton.interactable = false;

        Dialog dialog = quest.GetCurrentDialog();

        text.text = dialog.text;
        image.sprite = dialog.sprite;
        pageCounter.text = quest.GetPageCounter();
    }
    

    private void GoNextPageDialog(Quest quest)
    {
        quest.GoNextDialog();
        SetDialog(quest);
    }


    private void GoPreviousPageDialog(Quest quest)
    {
        quest.GoPreviousDialog();
        SetDialog(quest);
    }


    private void CloseDialog()
    {
        StartCoroutine(Utils.DoFadeOut(GetComponent<CanvasGroup>()));
    }
}
