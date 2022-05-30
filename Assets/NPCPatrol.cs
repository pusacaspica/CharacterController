using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPatrol : MonoBehaviour
{
    public List<Transform> goals;
    private int goal;
    // Start is called before the first frame update
    void Start()
    {
        goal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goals[goal].position;
        if(this.transform.position == goals[goal].position){
            goal++;
            if(goal == goals.Count  ) goal = 0;
        }
    }
}
