using System.Collections;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public Animator animator;

    private bool isPlaying = false;

    void Start()
    {
        // FREEZE animator at start
        animator.enabled = false;
    }

    // Called from UI Button
    public void PlayAnimation()
    {
        if (isPlaying) return;

        StartCoroutine(PlayOnce());
    }

    private IEnumerator PlayOnce()
    {
        isPlaying = true;

        // UNFREEZE animator so it can play
        animator.enabled = true;

        // Force reset to idle first
        animator.Play("Idle", 0, 0f);
        animator.Update(0f);

        yield return null;

        // Trigger animation
        animator.SetTrigger("Play");

        // Wait for Animator to enter state
        yield return null;

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float duration = stateInfo.length;

        yield return new WaitForSeconds(duration);

        // Return to idle
        animator.Play("Idle", 0, 0f);
        animator.Update(0f);

        // FREEZE again
        animator.enabled = false;

        isPlaying = false;
    }
}