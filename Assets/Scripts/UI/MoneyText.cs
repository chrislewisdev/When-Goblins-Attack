using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
	private Text text;
	private int money = 0;

	void Start()
	{
		text = GetComponent<Text>();
		Events.CoinPickedUp += this.CoinPickedUp;
	}

    private void CoinPickedUp()
    {
        money++;
		UpdateText();
    }

	private void UpdateText()
	{
		text.text = "$" + money;
	}
}
