using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variables
    [SerializeField]
    private TextMeshProUGUI questObjectiveText;
    [SerializeField]
    private GameObject dialogBox;
    private GameObject gameOver;
    public Quest initialQuest;
    public Quest currentQuest;
    public PlayerMovement player;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();

        // Start initial quest
        currentQuest = initialQuest;
        OpenDialog(currentQuest);
    }
    

    // Update is called once per frame
    void Update()
    {
        var dist = Math.Round(Vector2.Distance(currentQuest.objectiveLocation, player.transform.position), 0);
        questObjectiveText.text = currentQuest.objective + $" ({dist}m)";


        if (Input.GetKeyDown(KeyCode.Return) && isGameOver)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void OpenDialog(Quest quest)
    {
        dialogBox.GetComponent<DialogBox>().StartDialog(quest);
        StartCoroutine(Utils.DoFadeIn(dialogBox.GetComponent<CanvasGroup>()));
    }


    public void ShowGameOver()
    {
        if (!isGameOver)
        {
            gameOver = GameObject.Find("GameOver");
            gameOver.SetActive(true);
            StartCoroutine(Utils.DoFadeIn(gameOver.GetComponent<CanvasGroup>()));
            isGameOver = true;
        }
    }

}
