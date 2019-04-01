using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class TargetSpawner : Area {
    public GameObject targetPrefab;
    public GameObject[] spawnPoints;
    public int score =-1;
    int targetNum;
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

        
        //for (int i = 0; i < this.gameObject.transform.childCount; i++)
        //{
        //    if (this.gameObject.transform.GetChild(i).tag == "Target")
        //    {
        //        targetNum++;
        //    }
        //}

        //if (targetNum > 1)
        //{
        //    GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");

        //    for (int i = 1; i < targets.Length; i++)
        //    {
        //        if (targets[i].transform.parent = this.gameObject.transform)
        //        {
        //            Destroy(targets[i]);
        //        }
        //    }

        //}






        //if (this.gameObject.transform.Ge("Target").Length > 1)
        //{
        //    Destroy(GameObject.FindGameObjectsWithTag("Target")[0]);
        //}
    }

    void AddScore()
    {
        score++;
        print("Score = " + score);
    }
}
