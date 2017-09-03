using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField]
	private GameObject ObjectToSpawn;
	[SerializeField]
	private float SpawnTime = 3f;
    [SerializeField]
    private float Width = 1f;
	[SerializeField]
    private float Height = 1f;
	[SerializeField]
    private bool DrawGizmos = true;

    // Use this for initialization
    void Start()
    {
		InvokeRepeating("Spawn", SpawnTime + Random.Range(0f, 1f), SpawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

	private void Spawn()
	{
		Vector3 spawnPosition = new Vector3(Random.Range(0, Width) - Width/2, Random.Range(0, Height) - Height/2, 0);
		GameObject.Instantiate(ObjectToSpawn, transform.position + spawnPosition, Quaternion.identity);
	}

    void OnDrawGizmos()
    {
		if (DrawGizmos)
        {
            Gizmos.DrawWireCube(transform.position, new Vector3(Width, Height, 1));
        }
    }
}
