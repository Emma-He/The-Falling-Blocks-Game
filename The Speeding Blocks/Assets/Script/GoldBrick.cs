using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBrick : MonoBehaviour
{
	public Vector2 bspeedMinMax;
	float speed;

	float visibleHeightThreshold;

	void Start()
	{
		speed = Mathf.Lerp(bspeedMinMax.x, bspeedMinMax.y, Difficulty.GetDifficultyPercent());

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
