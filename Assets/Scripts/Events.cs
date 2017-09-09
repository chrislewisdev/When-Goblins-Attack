using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EnemyDied();
public delegate void WaveStarted(int enemyCount);

public class Events
{
	public static event EnemyDied EnemyDied;
	public static void FireEnemyDied()
	{
		if (EnemyDied != null) EnemyDied();
	}

	public static event WaveStarted WaveStarted;
	public static void FireWaveStarted(int enemyCount)
	{
		if (WaveStarted != null) WaveStarted(enemyCount);
	}
}
