using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackEnemy: MonoBehaviour
{
    public Transform hammerTransform;
    public Transform playerTrans;

    
    public float attachOffset = 1f;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    [SerializeField]
    private bool isAttaching = false;

    public bool goingToHammer = true;

    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        playerTrans = GameObject.Find("PlayerArmature").transform;
        hammerTransform = GameObject.Find("Hammer").transform;
    }

    void Update()
    {
        if (goingToHammer)
            navMeshAgent.SetDestination(hammerTransform.position);

        // Check if reached destination
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.hasPath)
        {
            hammerTransform.SetParent(this.transform);
            isAttaching = true;
            goingToHammer = false;
            
        }
        if (!goingToHammer)
            navMeshAgent.SetDestination(playerTrans.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isAttaching)
        {
            Debug.Log("up");
            SceneManager.LoadScene("EndingScene");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
    if (collision.gameObject.CompareTag("Player") && isAttaching)
    {
        SceneManager.LoadScene("EndingScene");
    }
    }
}
