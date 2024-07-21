using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Example logic for walking
        bool Walking = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
        animator.SetBool("Walking", Walking);

        // Example logic for throwing
        // Replace this with your actual throwing condition
        bool Throw = Input.GetMouseButtonDown(0); // Example: mouse button pressed
        animator.SetBool("Throw", Throw);

        // Set idle state if neither walking nor throwing
        if (!Walking && !Throw)
        {
            animator.SetBool("Idle", true);
        }
        else
        {
            animator.SetBool("Idle", false);
        }
    }
}
