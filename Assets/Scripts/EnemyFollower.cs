using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : Follower
{
	[SerializeField]
	private float AggroRange = 5f;
	[SerializeField]
	private LayerMask TargetLayer;

    protected override Vector3 GetTargetPosition()
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

    protected override void OnDrawGizmos()
    {
		base.OnDrawGizmos();
		
		if (ShouldDrawGizmos)
        {
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, AggroRange);
        }
    }
}
