using System.Collections;
using UnityEngine;

[System.Serializable]
public class Wave
{
	[SerializeField]
	private int enemyCount;
	public int EnemyCount { get { return enemyCount; } }
	[SerializeField]
	private int duration;
	public int Duration { get { return duration; } }
}

public class WaveManager : MonoBehaviour
{
	[SerializeField]
	private Wave[] Waves;
	[SerializeField]
    private float TimeBetweenWaves = 1f;

	private Spawner[] spawners;
	private int currentWave = -1;
	private int enemiesKilled = 0;

    // Use this for initialization
    void Start()
    {
		Events.EnemyDied += this.EnemyDied;

		spawners = GetComponentsInChildren<Spawner>();

		StartNextWave();
    }

    private void EnemyDied()
    {
        enemiesKilled++;

		if (enemiesKilled >= Waves[currentWave].EnemyCount)
		{
			StartCoroutine(StartNextWaveIn(TimeBetweenWaves));
		}
    }

	private IEnumerator StartNextWaveIn(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		StartNextWave();
	}

    private void StartNextWave()
	{
		currentWave = Mathf.Min(currentWave + 1, Waves.Length - 1);

		Debug.Log("Starting Wave " + currentWave);
		StartWave(Waves[currentWave]);
	}

	private void StartWave(Wave wave)
	{
		enemiesKilled = 0;

		for (int i = 0; i < wave.EnemyCount; i++)
		{
			Spawner spawner = spawners[Random.Range(0, spawners.Length)];
			spawner.Invoke("Spawn", Random.Range(0, wave.Duration));
		}

		Events.FireWaveStarted(wave.EnemyCount);
	}
}
