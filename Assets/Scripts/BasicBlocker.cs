using UnityEngine;

public class BasicBlocker : MonoBehaviour, IBlockerLogicHandler {
    [SerializeField]
    private string targetGesture;

    public virtual void HandleGesture(string gesture) {
        if (gesture == targetGesture) HandleCorrectGesture();
        else HandleIncorrectGesture();
    }

    public virtual void HandleCorrectGesture() {
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    public virtual void HandleIncorrectGesture() {

    }
}
