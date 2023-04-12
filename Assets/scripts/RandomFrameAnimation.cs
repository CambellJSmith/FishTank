using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFrameAnimation : MonoBehaviour
{
    private Animator animator;
    public string animationName;
    public float minOffset;
    public float maxOffset;

    void Start()
    {
        animator = GetComponent<Animator>();
        float randomOffset = Random.Range(minOffset, maxOffset);
        var state = animator.GetCurrentAnimatorStateInfo(0);
        animator.Play(animationName, -1, (randomOffset + state.normalizedTime) % 1);
    }
}