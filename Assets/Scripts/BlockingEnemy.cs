using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class BlockingEnemy : MonoBehaviour
{
    public Transform bowlTransform;
    public Transform startAreaTransform;
    public float attachOffset = 1f;
    private NavMeshAgent navMeshAgent;

    [SerializeField]
    private bool isAttaching = false;

    public bool goingToBowl = true;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        startAreaTransform = GameObject.Find("Start").transform;
        bowlTransform = GameObject.Find("Bowl").transform;
    }

    void Update()
    {
        if (goingToBowl)
            navMeshAgent.SetDestination(bowlTransform.position);

        // Check if reached destination
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.hasPath)
        {
            bowlTransform.SetParent(this.transform);
            isAttaching = true;
            goingToBowl = false;
            
        }
        if (!goingToBowl)
            navMeshAgent.SetDestination(startAreaTransform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Start") && isAttaching)
        {
            Debug.Log("up");
            SceneManager.LoadScene("EndingScene");
        }
    }

    void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Start") && isAttaching)
    {
        SceneManager.LoadScene("EndingScene");
    }
}

}
