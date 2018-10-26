using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 1. 8-directional movement
/// 2. stop and face current direction when input is absent
/// </summary>
public class MarioController : MonoBehaviour {

	public float velocity = 5;
	public float turnSpeed = 10;

	Vector2 input;
	float angle;

  bool jumping;

	Quaternion targetRotation;
	Transform cam;
  Animator anim;

	void Start() {
		cam = Camera.main.transform;
    anim = GetComponent<Animator>();
	}

	void Update() {
		GetInput();

		if (Mathf.Abs(input.x) < 1 && Mathf.Abs(input.y) < 1) return;

		CalculateDirection();
		Rotate();
		Move();

    if (Input.GetKeyDown(KeyCode.Space))
    {
      Jump();
    }

	}

  private void FixedUpdate()
  {

  }

  /// <summary>
  /// Input based on Horizontal(a,d,<,>) and Vertical (w,s,^,v) keys
  /// </summary>
  void GetInput() {
		input.x = Input.GetAxis("Horizontal");
    input.y = Input.GetAxis("Vertical");

    anim.SetFloat("BlendX", input.x);
    anim.SetFloat("BlendY", input.y);
	}

	/// <summary>
	/// Direction relative to the camera's rotation
	/// </summary>
	void CalculateDirection() {
		angle = Mathf.Atan2(input.x, input.y);
		angle = Mathf.Rad2Deg * angle;
		angle += cam.eulerAngles.y;
	}

	/// <summary>
	///	Rotate toward the calculated angle
	/// </summary>
	void Rotate() {
		targetRotation = Quaternion.Euler(0, angle, 0);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
	}

	/// <summary>
	/// This player only moves along its own forward axis
	/// </summary>
	void Move() {
		transform.position += transform.forward * velocity * Time.deltaTime;
	}

  void Jump(){
    //transform.position += transform.up * (200*Time.deltaTime);
    GetComponent<Rigidbody>().AddForce(new Vector3(0,6,0), ForceMode.Impulse);
    anim.SetTrigger("jump");
    Debug.Log("Jump Fired");
  }

  private void OnCollisionEnter(Collision collision)
  {
    if(collision.transform.tag == "cube"){
      anim.SetTrigger("FallBack");
      //Debug.Break();
    }
  }

}
