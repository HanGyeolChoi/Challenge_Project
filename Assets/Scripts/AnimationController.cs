using UnityEngine;

public class AnimationController : MonoBehaviour
{
    //private Controller controller;
    protected Animator animator;

    protected void Awake()
    {
        animator = GetComponent<Animator>();
        //controller = GetComponent<Controller>();
    }

}