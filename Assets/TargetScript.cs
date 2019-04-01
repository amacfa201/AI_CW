using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetScript : MonoBehaviour {
    //TargetSpawner ts;
    public int score;
   
    private void OnDestroy()
    {
        //score++;
       // ts = GameObject.FindGameObjectWithTag("Enviroment").GetComponent<TargetSpawner>();
       // ts.SpawnTarget();
    }
}
