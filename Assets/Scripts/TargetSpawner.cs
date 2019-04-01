using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class TargetSpawner : Area {
    public GameObject targetPrefab;
    public GameObject[] spawnPoints;
    public int score =-1;
    // Use this for initialization
    void Start() {
        SpawnTarget();
    }

    // Update is called once per frame
    void Update() {

    }


    public void SpawnTarget()
    {
        GameObject spawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject target = Instantiate(targetPrefab, spawn.transform);
        //target.transform.parent = GameObject.FindGameObjectWithTag("Spawn").transform;
        AddScore();

        if (GameObject.FindGameObjectsWithTag("Target").Length > 1)
        {
            Destroy(GameObject.FindGameObjectsWithTag("Target")[0]);
        }
    }

    void AddScore()
    {
        score++;
        print("Score = " + score);
    }
}
