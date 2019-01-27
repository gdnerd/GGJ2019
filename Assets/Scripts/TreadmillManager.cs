using System.Collections.Generic;
using UnityEngine;

public class TreadmillManager : MonoBehaviour {
    [SerializeField]
    private float givenTime = 10f;
    [SerializeField]
    public float currentSpeed = 10f;
    public float targetSpeed = 10f;
    private float startTime;
    [SerializeField]
    private List<GameObject> treadmillPiecePrefabs;
    private List<GameObject> treadmillPieces;

    private static TreadmillManager instance;
    public static TreadmillManager Instance {
        get { return instance; }
        set { instance = value; }
    }

    Rigidbody rigidbody;

    private void Start() {
        Instance = this;
        rigidbody = GetComponent<Rigidbody>();
        startTime = Time.time;
        treadmillPieces = new List<GameObject>();
        for (int i = 0; i < 10; i++) {
            if (i < 3) {
                treadmillPieces.Add(Instantiate(treadmillPiecePrefabs[i], new Vector3(transform.position.x, 0, transform.position.z - 20 * (i + 2)), Quaternion.identity, this.transform));
            } else {
                treadmillPieces.Add(Instantiate(treadmillPiecePrefabs[Random.Range(0, treadmillPiecePrefabs.Count)], new Vector3(transform.position.x, 0, transform.position.z - 20 * (i + 2)), Quaternion.identity, this.transform));
            }
        }
    }

    private void Update() {
        if(Time.time - startTime > givenTime) {
            Debug.Log("Ran out of time!");
            //SceneManager.LoadScene(2);
        }

        rigidbody.MovePosition(transform.position + Vector3.forward * currentSpeed * Time.deltaTime);
    }
}
