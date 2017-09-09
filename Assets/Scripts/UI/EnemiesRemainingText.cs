using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesRemainingText : MonoBehaviour
{
	private Text text;
	private int enemiesRemaining = 0;

	void Start()
	{
		text = GetComponent<Text>();
		Events.EnemyDied += this.EnemyDied;
		Events.WaveStarted += this.WaveStarted;
	}

    private void WaveStarted(int enemyCount)
    {
        enemiesRemaining = enemyCount;
		UpdateText();
    }

    private void EnemyDied()
    {
        enemiesRemaining--;
		UpdateText();
    }

	private void UpdateText()
	{
		if (enemiesRemaining > 0)
		{
			text.text = "Enemies: " + enemiesRemaining;
		}
		else
		{
			text.text = "Wave Complete!";
		}
	}
}
