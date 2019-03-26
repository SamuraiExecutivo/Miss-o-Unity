using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesSpawner : MonoBehaviour {

	public GameObject []    resourcesObjects;
	public float            spawnTime;
	public Vector3          spawnPoint;
	public float            spawnTimer;

	// Use this for initialization
	void Awake () {
		spawnTime = 7f;
        spawnTimer = 0;
	}
	
	void FixedUpdate () {
		TimeCheckOut ();
	}

    void TimeCheckOut () {
        if (Time.timeScale != 0) {
            spawnTimer += 1 * Time.deltaTime;
            if (spawnTime > 1) spawnTime -= 0.1f * Time.deltaTime; 
            if (spawnTimer > spawnTime) {
                Spawn ();
                spawnTimer = 0;
            }  
        }
    }

	void Spawn () {
         spawnPoint.x = Random.Range (-12, 12);
         spawnPoint.y = Random.Range (-8, 8);
         Instantiate(resourcesObjects[UnityEngine.Random.Range(0, resourcesObjects.Length - 1)], spawnPoint, Quaternion.identity);
     }
}
