using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMouseFollower : MonoBehaviour
{
	private NavMeshAgent navMeshAgent;

	void Start()
	{
		navMeshAgent = GetComponentInParent<NavMeshAgent>();

		if (!navMeshAgent) Debug.LogWarning("No NavMeshAgent for NavMeshMouseFollower. This component needs to reside under a NavMeshAgent!");
	}

	void Update()
	{
		Vector3 targetPosition = GetTargetPosition();
		targetPosition.z = 0;

		if (navMeshAgent.isActiveAndEnabled) navMeshAgent.SetDestination(targetPosition);
	}


    private Vector3 GetTargetPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);;
    }
}
