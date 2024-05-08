using UnityEngine;

internal class WaitForAnimationToFinish
{
    private Animator animator;
    private string v;

    public WaitForAnimationToFinish(Animator animator, string v)
    {
        this.animator = animator;
        this.v = v;
    }
}