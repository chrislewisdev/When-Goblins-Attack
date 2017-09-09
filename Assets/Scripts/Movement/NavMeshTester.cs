using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshTester : MonoBehaviour
{
	private NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
		agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
		{
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.z = 0;
            agent.SetDestination(target);
        }
    }
}
