using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : MonoBehaviour
{
	[SerializeField]
	private float AggroRange = 5f;
	[SerializeField]
	private LayerMask TargetLayer;
	[SerializeField]
    private float SmoothTime = 0.5f;
    [SerializeField]
    private float MaxSpeed = 1f;
    [SerializeField]
    private float GoodEnoughRange = 5f;
    [SerializeField]
    private float SlowdownSpeed = 0.25f;
    [SerializeField]
    private bool DrawGizmos = true;

    private new Rigidbody2D rigidbody;

    private Vector3 targetPosition;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		Collider2D nearestEnemy = Physics2D.OverlapCircle(transform.position, AggroRange, TargetLayer);

		if (nearestEnemy)
		{
			targetPosition = nearestEnemy.transform.position;
			targetPosition.z = 0;
		}
		else
		{
			targetPosition = transform.position;
		}

		float distanceToTarget = (transform.position - targetPosition).magnitude;
		if (distanceToTarget > GoodEnoughRange)
		{
			Vector3 velocity = rigidbody.velocity;
			Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime, MaxSpeed);
			rigidbody.velocity = velocity;
		}
		else
		{
			rigidbody.velocity = Vector2.MoveTowards(rigidbody.velocity, Vector2.zero, SlowdownSpeed * Time.deltaTime);
		}
    }

    void OnDrawGizmos()
    {
		if (DrawGizmos)
        {
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, AggroRange);

			Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, targetPosition);
            Gizmos.DrawWireSphere(targetPosition, GoodEnoughRange);
        }
    }
}
