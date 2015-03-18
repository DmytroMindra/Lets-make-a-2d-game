using UnityEngine;
using System.Linq;
using System.Collections;

public class HeroController : MonoBehaviour {

	// Running
	public float maxVelocity;
	public float force;
	public float jumpForce;
	public Transform groundCheck;
	public LayerMask whatIsGround;

	// Shooting
	public Transform gunMuzzle;
	public GameObject bulletPrefab;
	public float shotsPersecond;
	private float nextShotTime;


	Animator animator;

	void Start()
	{
		animator = GetComponent<Animator> ();
	}

	bool IsGrounded ()
	{
		return Physics2D.OverlapCircle (groundCheck.position, 0.1f, whatIsGround);
	}

	void Update () 
	{
		if (this.GetComponent<Rigidbody2D>().velocity.x < maxVelocity)
		{
			this.GetComponent<Rigidbody2D>().AddForce (Vector2.right * force, ForceMode2D.Force);
		}

		if (Input.GetButton ("Fire1") && Time.time > nextShotTime) 
		{
			nextShotTime=Time.time + 1f/shotsPersecond;
			bulletPrefab.Spawn(gunMuzzle.position,gunMuzzle.rotation);
		}

	}

	void FixedUpdate() 
	{
		bool grounded = IsGrounded ();

		if (Input.GetButton("Jump") && grounded) 
		{
			GetComponent<Rigidbody2D>().AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
		}

		animator.SetBool ("isJumping",!grounded);
	}

	public void RestoreHeroPosition() 
	{
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		transform.position = new Vector3(0, transform.position.y, transform.position.z);
	}


}
