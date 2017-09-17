using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDropper : MonoBehaviour
{
	[SerializeField]
	[Range(0, 1)]
	private float DropChance = 0.2f;
	[SerializeField]
	private GameObject PrefabToSpawn;

	void OnDestroy()
	{
		if (Random.value < DropChance)
		{
			GameObject.Instantiate(PrefabToSpawn, transform.position, Quaternion.identity);
		}
	}
}
