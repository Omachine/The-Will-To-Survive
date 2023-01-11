using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject toBeContinued;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // On trigger enter 2D, if player and its quest with objective "Encontrar um lugar seguro." is completed, load scene "EndGame"
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (collision.CompareTag("Player") && gameManager.currentQuest.objective == "Encontrar um lugar seguro.") //  
        {
            // show to be continued object
            StartCoroutine(Utils.DoFadeIn(toBeContinued.GetComponent<CanvasGroup>()));
            gameManager.isGameOver = true;
        }
    }
}
