using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos = new Vector3(12, -3, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController PlayerController;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController = GameObject.Find("PlayerSprite").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (PlayerController.gameOver == false)
        {
            var obstacleSelected = Random.Range(0,obstaclePrefab.Length);
            Instantiate(obstaclePrefab[obstacleSelected], spawnPos, obstaclePrefab[obstacleSelected].transform.rotation);
        }
    }
}
