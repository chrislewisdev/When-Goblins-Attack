using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemyFollower : MonoBehaviour
{
	[SerializeField]
	private float AggroRange = 5f;
	[SerializeField]
	private LayerMask TargetLayer;
	[SerializeField]
    private bool DrawGizmos = false;

	private NavMeshAgent navMeshAgent;

	void Start()
	{
		navMeshAgent = GetComponentInParent<NavMeshAgent>();

		if (!navMeshAgent) Debug.LogWarning("No NavMeshAgent for NavMeshEnemyFollower. This component needs to reside under a NavMeshAgent!");
	}

	void Update()
	{
		Vector3 targetPosition = GetTargetPosition();
		targetPosition.z = 0;

		if (navMeshAgent.isActiveAndEnabled) navMeshAgent.SetDestination(targetPosition);
	}

    void OnDrawGizmos()
    {
		if (DrawGizmos)
        {
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, AggroRange);
        }
    }

    private Vector3 GetTargetPosition()
    {
        Collider2D nearestEnemy = Physics2D.OverlapCircle(transform.position, AggroRange, TargetLayer);

		if (nearestEnemy)
		{
			return nearestEnemy.transform.position;
		}
		else
		{
			return transform.position;
		}
    }
}
