using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorting : MonoBehaviour
{
	private SpriteRenderer sprite;

    // Use this for initialization
    void Start()
    {
		sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		sprite.sortingOrder = (int)(-transform.position.y * 100);
    }
}
