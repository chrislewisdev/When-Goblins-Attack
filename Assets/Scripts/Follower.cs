using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Follower : MonoBehaviour
{
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
	public bool ShouldDrawGizmos { get { return DrawGizmos; } }

    private new Rigidbody2D rigidbody;

    private Vector3 targetPosition;

	protected abstract Vector3 GetTargetPosition();

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = GetTargetPosition();
        targetPosition.z = 0;

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

    protected virtual void OnDrawGizmos()
    {
		if (DrawGizmos)
        {
            Gizmos.DrawLine(transform.position, targetPosition);
            Gizmos.DrawWireSphere(targetPosition, GoodEnoughRange);
        }
    }
}
