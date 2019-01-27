using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBlocker : BasicBlocker {
    Animator animator;
    Collider collider;

    private void Start() {
        animator = gameObject.GetComponent<Animator>();
        this.collider = gameObject.GetComponent<Collider>();
    }

    public void DisableCollider() {
        this.collider.enabled = false;
        TreadmillManager.Instance.currentSpeed = TreadmillManager.Instance.targetSpeed;
    }

    public override void HandleCorrectGesture() {
        animator.SetTrigger("CorrectGesture");
    }
}
