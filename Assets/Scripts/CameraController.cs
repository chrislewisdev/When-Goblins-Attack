using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private float MaxMoveSpeed = 1f;
	[SerializeField]
	private Vector2 MouseBounds;
	[SerializeField]
	private bool DrawGizmos = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition.z = transform.position.z;

		Vector3 deltaPosition = transform.position - mousePosition;
		if (Mathf.Abs(deltaPosition.x) > MouseBounds.x / 2 || Mathf.Abs(deltaPosition.y) > MouseBounds.y / 2)
		{
			transform.position = Vector3.MoveTowards(transform.position, mousePosition, MaxMoveSpeed);
		}
    }

	void OnDrawGizmos()
	{
		if (DrawGizmos)
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireCube(transform.position, MouseBounds);
		}
	}
}
