using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBlock : MonoBehaviour
{
	
	float speed;

	float visibleHeightThreshold;

	void Start()
	{
		speed = Mathf.Lerp(7, 15, Difficulty.GetDifficultyPercent());

		visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
	}

	void Update()
	{
		transform.Translate(Vector3.down * speed * Time.deltaTime, Space.Self);

		if (transform.position.y < visibleHeightThreshold)
		{
			Destroy(gameObject);
		}
	}
}