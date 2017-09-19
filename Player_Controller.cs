using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

	//Evaluation of code at the bottom


	public float movement_Speed;



	private Vector3 jump;

	public float jump_Height;

	private float moveFallOff;

	//Movement 
		//Forwards and Backwards
	private bool wPressed;
	private bool sPressed;

	private bool wReleased;
	private bool sReleased;

		//Side to side
	private bool aPressed;
	private bool dPressed;

	private bool aReleased;
	private bool dReleased;

	private bool space;

	public Rigidbody rb;




	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		wPressed = Input.GetKey (KeyCode.W);
		sPressed = Input.GetKey (KeyCode.S);

		wReleased = Input.GetKeyUp (KeyCode.W);
		sReleased = Input.GetKeyUp (KeyCode.S);

		aPressed = Input.GetKey (KeyCode.A);
		dPressed = Input.GetKey (KeyCode.D);

		aReleased = Input.GetKeyUp (KeyCode.A);
		dReleased = Input.GetKeyUp (KeyCode.D);

		space = Input.GetKeyDown (KeyCode.Space);

		jump = new Vector3 (0, 2f, 0);

		moveFallOff = 20f;

	}



	void FixedUpdate()
	{
		if (wPressed == true) 
		{
			rb.AddForce (Vector3.forward* movement_Speed);

			if (wReleased == true)
			{
				rb.AddForce (-Vector3.forward * movement_Speed * moveFallOff);
			}
		}

		if (sPressed == true) 
		{
			rb.AddForce (-Vector3.forward * movement_Speed);

			if (sReleased == true)
			{
				rb.AddForce (Vector3.forward * movement_Speed * moveFallOff);
			}

		}

		if (aPressed == true) 
		{

			rb.AddForce (Vector3.left * movement_Speed);
			if (aReleased == true)
			{
				rb.AddForce (Vector3.right * movement_Speed * moveFallOff);
			}
		}

		if (dPressed == true) 
		{

			rb.AddForce (Vector3.right *movement_Speed);

			if (aReleased == true)
			{
				rb.AddForce (Vector3.left * movement_Speed * moveFallOff);
			}
		}

		if (space == true) 
		{
			Jump ();

		}

	}


	void Jump()
	{

		rb.AddForce (jump * jump_Height, ForceMode.Impulse);

	}
}


/*Evaluation: A movement speed and jump height were both impliment correctly has public variable allowing them to be changed in the unity editor. A jump funciton was added so that 
when the key space was pressed an if statement would call the jump function. Implimenting the jump function in this way is more effiecent, especially in cases where the jump
function needs to be called in multiple instances (just by using Jump(); rather than retyping the jump script). However the intial method of movement was going to be a 3d platformer 
movement with A and D turning the character left and right that was scrapped and replaced with A and D moving the character left and right. An improvement would be to add a 
bool to track whether the player is touching the ground or not, if yes then the player can jump if not then player cannot. Also having the movement move forward to objects 'forward'
rather than the global forward.   */ 
