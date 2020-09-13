using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MovementController;

public class PlayerMovement : MonoBehaviour
{
    // movement config
    [SerializeField]
    float gravity = -25f;
    [SerializeField]
    float runSpeed = 8f;
    [SerializeField]
    float groundDamping = 20f; // how fast do we change direction? higher means faster
    [SerializeField]
    float inAirDamping = 5f;
    [SerializeField]
    float jumpHeight = 3f;

	[HideInInspector]
	private float normalizedHorizontalSpeed = 0;

	private CharacterController2D controller;

	private RaycastHit2D lastControllerColliderHit;
	private Vector3 velocity;

	void Awake()
    {
        controller = GetComponent<CharacterController2D>();

        //controller.onControllerCollidedEvent += onControllerCollider;
        //controller.onTriggerEnterEvent += onTriggerEnterEvent;
        //controller.onTriggerExitEvent += onTriggerExitEvent;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (controller.isGrounded)
			velocity.y = 0;

		if (Input.GetKey(KeyCode.D))
		{
			normalizedHorizontalSpeed = 1;
			if (transform.localScale.x < 0f)
				transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

			//if (controller.isGrounded)
				//_animator.Play(Animator.StringToHash("Run"));
		}
		else if (Input.GetKey(KeyCode.A))
		{
			normalizedHorizontalSpeed = -1;
			if (transform.localScale.x > 0f)
				transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

			//if (controller.isGrounded)
				//_animator.Play(Animator.StringToHash("Run"));
		}
		else
		{
			normalizedHorizontalSpeed = 0;

			//if (controller.isGrounded)
				//_animator.Play(Animator.StringToHash("Idle"));
		}


		// we can only jump whilst grounded
		if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
		{
			velocity.y = Mathf.Sqrt(2f * jumpHeight * -gravity);
			//_animator.Play(Animator.StringToHash("Jump"));
		}


		// apply horizontal speed smoothing it. dont really do this with Lerp. Use SmoothDamp or something that provides more control
		var smoothedMovementFactor = controller.isGrounded ? groundDamping : inAirDamping; // how fast do we change direction?
		velocity.x = Mathf.Lerp(velocity.x, normalizedHorizontalSpeed * runSpeed, Time.deltaTime * smoothedMovementFactor);

		// apply gravity before moving
		velocity.y += gravity * Time.deltaTime;

		// if holding down bump up our movement amount and turn off one way platform detection for a frame.
		// this lets us jump down through one way platforms
		if (controller.isGrounded && Input.GetKey(KeyCode.DownArrow))
		{
			velocity.y *= 3f;
			controller.ignoreOneWayPlatformsThisFrame = true;
		}

		controller.move(velocity * Time.deltaTime);

		// grab our current _velocity to use as a base for all calculations
		velocity = controller.velocity;
	}
}

