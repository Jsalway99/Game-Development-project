using UnityEngine;
using UnityEngine.AI;
public class Enemymovment : MonoBehaviour
{
    public Transform Player;

    public float detectionRange = 15f;
    public float stoppingDistance = 2f;

    private NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = stoppingDistance;
    }
    // Update is called once per frame
    void Update()
    {
     if (Player == null)
            return;

     float distance = Vector3.Distance(transform.position, Player.position);
     
     if (distance < detectionRange)
        {
            //chase player
            if (agent.isOnNavMesh)
               
{ 
                    agent.SetDestination(Player.position);  
}
        }
     else
        {
            //Stop Chasing
            agent.ResetPath();
        }
    }
}
