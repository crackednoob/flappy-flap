using UnityEngine.Networking;
using UnityEngine;

public class ObjectPoolMultiplayer : NetworkBehaviour{

	public int obstaclePoolSize = 5;
	public GameObject obstaclePrefab;
	public float spawnRate = 4f;
	public float obstacleMin = -1f;
	public float obstacleMax = 3.5f;

	private GameObject[] obstacle;
	private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
	private float spawnXPosition = 12f;
	private int currentObstacle = 0;
	private float timeSinceLastSpawn;

	[SyncVar]
	private float spawnYPosition;
	[SyncVar]
	private int spawnNow;



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
		if (GameObject.FindGameObjectWithTag ("Player") == null)
			return;
		
		if (GameController.instance.gameOver == false && timeSinceLastSpawn >= spawnRate || spawnNow == 1) {
			timeSinceLastSpawn = 0;
			if (isServer) {
				spawnYPosition = Random.Range (obstacleMin, obstacleMax);
				spawnNow = 1;
			}
			SpawnResult (spawnYPosition);
			spawnNow = 0;
			currentObstacle++;
			if (currentObstacle >= obstaclePoolSize) {
				
				currentObstacle = 0;
			}
		}
	}
		
		
	void SpawnResult(float spawn)
	{
		obstacle [currentObstacle].transform.position = new Vector2 (spawnXPosition, spawn);	
	}
		

}
