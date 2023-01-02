using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    float speed;
    float visionDistance;
    [SerializeField] Transform target;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[0].transform;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        speed = Random.Range(1.5f, 2.5f);
        agent.speed = speed;

        visionDistance = Random.Range(4f, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        // check if player is in range
        if (Vector3.Distance(transform.position, target.position) < visionDistance)
        {
            // move towards player
            agent.SetDestination(target.position);
        }

        // Animate
        if (agent.velocity.magnitude > 0.1f)
        {
            GetComponent<Animator>().SetBool("isIdle", false); 
        }
        else
        {
            GetComponent<Animator>().SetBool("isIdle", true);
        }

        // If player is close enough, attack
        if (Vector3.Distance(transform.position, target.position) < 0.75f)
        {
            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameManager.ShowGameOver();
        }
    }
}
