using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EnemyDied();
public delegate void WaveStarted(int enemyCount);
public delegate void CoinPickedUp();

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

	public static event CoinPickedUp CoinPickedUp;
	public static void FireCoinPickedUp()
	{
		if (CoinPickedUp != null) CoinPickedUp();
	}
}
