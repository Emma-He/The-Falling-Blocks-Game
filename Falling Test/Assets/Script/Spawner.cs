using UnityEngine;
using System.Collections;
using System.Threading;
using System.Runtime.InteropServices;

public class Spawner : MonoBehaviour {

	public GameObject fallingBlockPrefab;
	public GameObject fallingGoldBrickPrefab;//gold brick object
	public GameObject fallingBloodBlockPrefab;

	public Vector2 secondsBetweenSpawnsMinMax;
	public Vector2 secondsBetweenBrickSpawnsMinMax;//time difference of brick spawn
	public Vector2 secondsBetweenBloodSpawnsMinMax;//time difference of brick spawn

	float nextSpawnTime;
	float nextBrickSpawnTime;//variable for the brick to spawn
	float nextBloodSpawnTime;


	public Vector2 spawnSizeMinMax;
	public Vector2 BrickSizeMinMax;//size of brick
	public Vector2 BloodSizeMinMax;
	public float spawnAngleMax;

	Vector2 screenHalfSizeWorldUnits;

	// Use this for initialization
	void Start () {
		screenHalfSizeWorldUnits = new Vector2 (Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > nextSpawnTime) {
			float secondsBetweenSpawns = Mathf.Lerp (secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent ());
			nextSpawnTime = Time.time + secondsBetweenSpawns;

			float spawnAngle = Random.Range (-spawnAngleMax, spawnAngleMax);
			float spawnSize = Random.Range (spawnSizeMinMax.x, spawnSizeMinMax.y);
			Vector2 spawnPosition = new Vector2 (Random.Range (-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
			GameObject newBlock = (GameObject)Instantiate (fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
			newBlock.transform.localScale = Vector2.one * spawnSize;
		}
		if (Time.time > nextBrickSpawnTime)
		{
			float secondsBetweenBricksSpawn = Mathf.Lerp(secondsBetweenBrickSpawnsMinMax.y, secondsBetweenBrickSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
			nextBrickSpawnTime = Time.time + secondsBetweenBricksSpawn;
			float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
			float spawnSize = Random.Range(BrickSizeMinMax.x,BrickSizeMinMax.y);
			Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
			GameObject newBlock = (GameObject)Instantiate(fallingGoldBrickPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
			newBlock.transform.localScale = Vector2.one * spawnSize;
		}
		if (Time.time > nextBloodSpawnTime)
		{
			float secondsBetweenBloodSpawn = Mathf.Lerp(secondsBetweenBloodSpawnsMinMax.y, secondsBetweenBloodSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
			nextBloodSpawnTime = Time.time + secondsBetweenBloodSpawn;
			float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
			float spawnSize = Random.Range(BloodSizeMinMax.x, BloodSizeMinMax.y);
			Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
			GameObject newBlock = (GameObject)Instantiate(fallingBloodBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
			newBlock.transform.localScale = Vector2.one * spawnSize;
			
		}
	}
}