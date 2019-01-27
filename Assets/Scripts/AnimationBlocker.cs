using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBlocker : BasicBlocker {
    Animator animator;
    Collider collider;

    private void Start() {
        animator = gameObject.GetComponent<Animator>();
        collider = gameObject.GetComponent<Collider>();
    }

    public void DisableCollider() {
        collider.enabled = false;
    }

    public override void HandleCorrectGesture() {
        animator.SetTrigger("CorrectGesture");
    }
}
