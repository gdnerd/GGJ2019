﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreadmillManager : MonoBehaviour {
    [SerializeField]
    private float givenTime = 10f;
    [SerializeField]
    private float speed = 5f;
    private float startTime;
    [SerializeField]
    private List<GameObject> treadmillPiecePrefabs;
    private List<GameObject> treadmillPieces;

    private void Start() {
        startTime = Time.time;
        treadmillPieces = new List<GameObject>();
        for(int i = 0; i < 10; i++) {
            treadmillPieces.Add(Instantiate(treadmillPiecePrefabs[Random.Range(0, treadmillPiecePrefabs.Count)], new Vector3(0, 0, 40*i), Quaternion.identity, this.transform));
        }
    }

    private void Update() {
        if(Time.time - startTime > givenTime) {
            Debug.Log("Ran out of time!");
            //SceneManager.LoadScene(2);
        }

        transform.position += Vector3.back * speed * Time.deltaTime;
    }
}