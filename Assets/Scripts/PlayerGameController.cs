using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGameController : MonoBehaviour {
    RaycastHit hit;

    private void OnTriggerEnter(Collider other) {
        SceneManager.LoadScene(2);
    }

    private void Update() {
        if (Input.GetKey(KeyCode.P)) {
            HandleGesture("Slap");
        }else if (Input.GetKey(KeyCode.O)) {
            HandleGesture("Talk");
        }
    }

    public void HandleGesture(string gesture) {
        Ray ray = new Ray(transform.position, Vector3.forward);
        if(Physics.Raycast(ray, out hit, 1f, LayerMask.GetMask("Blockers"), QueryTriggerInteraction.Collide)) {
            hit.collider.transform.GetComponent<BasicBlocker>().HandleGesture(gesture);
        }
    }
}
