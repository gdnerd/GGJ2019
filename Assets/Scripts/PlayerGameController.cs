using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGameController : MonoBehaviour {
    RaycastHit hit;
    [SerializeField]
    private float poopMeter = 0;
    [SerializeField]
    private float fillSpeed = 5;
    [SerializeField]
    private float poopThreshold = 50;
    private Transform poopMask;
    [SerializeField]
    private ParticleSystem poopsplosion;

    private void Start() {
        poopMask = GameObject.Find("PoopMask").transform;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Blocker") {
            TreadmillManager.Instance.currentSpeed = 0;
        } else if (other.tag == "Finish") {
            SceneManager.LoadScene("BathroomScene");
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
        } else {
            if (TreadmillManager.Instance.currentSpeed > 0) {
                TreadmillManager.Instance.currentSpeed = TreadmillManager.Instance.targetSpeed;
            }

            poopMeter += fillSpeed * Time.deltaTime;
        }

        poopMeter = Mathf.Clamp(poopMeter, 0, poopThreshold);

        if (poopMeter >= poopThreshold) {
            poopMeter = 0;
            fillSpeed = 0;
            TreadmillManager.Instance.currentSpeed = 0;
            TreadmillManager.Instance.targetSpeed = 0;
            poopsplosion.Play();
        }

        poopMask.localScale = new Vector3(poopMask.localScale.x, (poopMeter / poopThreshold) * 15f, poopMask.localScale.z);
    }

    public void HandleGesture(string gesture) {
        Ray ray = new Ray(transform.position, Vector3.back);
        if(Physics.Raycast(ray, out hit, 10f, LayerMask.GetMask("Blockers"), QueryTriggerInteraction.Collide)) {
            hit.collider.transform.GetComponent<BasicBlocker>().HandleGesture(gesture);
        }
    }
}
