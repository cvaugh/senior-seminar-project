using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    private Vector3 lastPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
    }
    void Update()
    {
        Vector3 currentPosition = transform.position;

        if (currentPosition != lastPosition) {
            animator.SetBool("isJogging", true);
        } else {
            animator.SetBool("isJogging", false);
        }

        lastPosition = currentPosition;
    }
}
