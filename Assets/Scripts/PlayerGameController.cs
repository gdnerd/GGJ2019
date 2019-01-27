using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGameController : MonoBehaviour {
    RaycastHit hit;
    [SerializeField]
    private float poopMeter = 0;
    [SerializeField]
    private float fillSpeed = 5;
    [SerializeField]
    private float poopThreshold = 5;


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

        if (Input.GetKey(KeyCode.C) && TreadmillManager.Instance.currentSpeed > 0) {
            TreadmillManager.Instance.currentSpeed = 1;
            poopMeter -= fillSpeed * Time.deltaTime;
            poopMeter = Mathf.Max(poopMeter, 0);
        } else {
            if (TreadmillManager.Instance.currentSpeed > 0) {
                TreadmillManager.Instance.currentSpeed = TreadmillManager.Instance.targetSpeed;
            }

            poopMeter += fillSpeed * Time.deltaTime;
        }

        if (poopMeter >= poopThreshold) Debug.Log("I Crapped My Pants");
    }

    public void HandleGesture(string gesture) {
        Ray ray = new Ray(transform.position, Vector3.forward);
        if(Physics.Raycast(ray, out hit, 1f, LayerMask.GetMask("Blockers"), QueryTriggerInteraction.Collide)) {
            hit.collider.transform.GetComponent<BasicBlocker>().HandleGesture(gesture);
        }
    }
}
