using System.Collections.Generic;
using UnityEngine;

public class TreadmillManager : MonoBehaviour {
    [SerializeField]
    private float givenTime = 10f;
    [SerializeField]
    private float speed = 5f;
    private float startTime;
    [SerializeField]
    private GameObject finalTreadmillPiecePrefab;
    [SerializeField]
    private List<GameObject> treadmillPiecePrefabs;
    private List<GameObject> treadmillPieces;
    Rigidbody rigidbody;

    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
        startTime = Time.time;
        treadmillPieces = new List<GameObject>();
        for(int i = 0; i < 10; i++) {
            treadmillPieces.Add(Instantiate(treadmillPiecePrefabs[Random.Range(0, treadmillPiecePrefabs.Count)], new Vector3(0, 0, 40*i), Quaternion.identity, this.transform));
        }
        treadmillPieces.Add(Instantiate(finalTreadmillPiecePrefab, new Vector3(0,0, 40*10), Quaternion.identity, this.transform));
    }

    private void Update() {
        if(Time.time - startTime > givenTime) {
            Debug.Log("Ran out of time!");
            //SceneManager.LoadScene(2);
        }

        rigidbody.MovePosition(transform.position + Vector3.back * speed * Time.deltaTime);
    }
}
