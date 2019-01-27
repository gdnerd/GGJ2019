using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGameController : MonoBehaviour {
    RaycastHit hit;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Blocker") {
            TreadmillManager.Instance.currentSpeed = 0;
        } else if (other.tag == "Finish") {
            SceneManager.LoadScene(2);
        }
    }

    private void Update() {
        if (Input.GetKey(KeyCode.P)) {
            HandleGesture("Slap");
        }else if (Input.GetKey(KeyCode.O)) {
            HandleGesture("Talk");
        }else if (Input.GetKey(KeyCode.L)) {
            HandleGesture("Pet");
        }
    }

    public void HandleGesture(string gesture) {
        Ray ray = new Ray(transform.position, Vector3.forward);
        if(Physics.Raycast(ray, out hit, 1f, LayerMask.GetMask("Blockers"), QueryTriggerInteraction.Collide)) {
            hit.collider.transform.GetComponent<BasicBlocker>().HandleGesture(gesture);
        }
    }
}
