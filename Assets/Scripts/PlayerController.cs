﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float moveSpeed;
	public float jumpSpeed;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public bool isGrounded;

	private Rigidbody2D rigidBody;
	private Animator animator;

	// Use this for initialization
	void Start ()
	{
		this.rigidBody = GetComponent<Rigidbody2D> ();
		this.animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		if (Input.GetAxisRaw ("Horizontal") > 0f) {
			rigidBody.velocity = new Vector3 (moveSpeed, rigidBody.velocity.y, 0f);
			transform.localScale = new Vector3(1f,1f,1f);
		} else if (Input.GetAxisRaw ("Horizontal") < 0f) {
			rigidBody.velocity = new Vector3 (-moveSpeed, rigidBody.velocity.y, 0f);
			transform.localScale = new Vector3(-1f,1f,1f);
		} else {
			rigidBody.velocity = new Vector3 (0f, rigidBody.velocity.y, 0f);
		}

		if (Input.GetButtonDown ("Jump") && isGrounded) {
			rigidBody.velocity = new Vector3 (rigidBody.velocity.x, jumpSpeed, 0f);
		}

		animator.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
		animator.SetBool("Grounded", isGrounded);

	}
}
