using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour {

	public int obstaclePoolSize = 5;
	public GameObject obstaclePrefab;
	public float spawnRate = 4f;
	public float obstacleMin = -1f;
	public float obstacleMax = 3.5f;

	private GameObject[] obstacle;
	private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
	private float timeSinceLastSpawn = 4f;
	private float spawnXPosition = 12f;
	private int currentObstacle = 0;

	void Start()
	{
		obstacle = new GameObject[obstaclePoolSize];
		for (int i = 0; i < obstaclePoolSize; i++) {

			obstacle [i] = (GameObject)Instantiate (obstaclePrefab, objectPoolPosition, Quaternion.identity);

		}
	}

	void Update()
	{
		timeSinceLastSpawn += Time.deltaTime;

		if(GameController.instance.gameOver == false && timeSinceLastSpawn >= spawnRate)
		{
			timeSinceLastSpawn = 0;
			float spawnYPosition = Random.Range (obstacleMin, obstacleMax);
			obstacle [currentObstacle].transform.position = new Vector2 (spawnXPosition, spawnYPosition);
			currentObstacle++;
			if (currentObstacle >= obstaclePoolSize) {

				currentObstacle = 0;
			}
		}
	}

}
