using UnityEngine;

public class BasicBlocker : MonoBehaviour, IBlockerLogicHandler {
    [SerializeField]
    private string targetGesture;

    public void HandleGesture(string gesture) {
        if (gesture == targetGesture) HandleCorrectGesture();
        else HandleIncorrectGesture();
    }

    public void HandleCorrectGesture() {
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    public void HandleIncorrectGesture() {

    }
}
