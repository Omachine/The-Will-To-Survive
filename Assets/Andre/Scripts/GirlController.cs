using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GirlController : MonoBehaviour
{
    [SerializeField]
    private GameObject talkWarning;
    public Quest[] quests;
    private Quest currentQuest;
    private GameManager gameManager;

    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        talkWarning.SetActive(false);

        if (quests.Length > 0) {
            currentQuest = quests[0];
            talkWarning.GetComponent<Button>().onClick.AddListener(() => {
                gameManager.OpenDialog(currentQuest);
            });
        }
        else
            currentQuest = null;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && currentQuest != null)
        {
            talkWarning.SetActive(true);
        }
    }

    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && currentQuest != null)
        {
            talkWarning.SetActive(false);
        }
    }

    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && currentQuest != null)
        {
            talkWarning.SetActive(true);
        }
    }
}
