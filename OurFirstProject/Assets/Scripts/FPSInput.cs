using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ChangeCamera))]
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

public class FPSInput : MonoBehaviour
{
	public float speed = 6.0f;
	public float gravity = -9.8f;
	private ChangeCamera cameraController;
	private CharacterController charController;
	private float rotateCount = 0f;
	private bool rotating = false;

	void Start()
	{
		cameraController = GetComponent<ChangeCamera>();
		charController = GetComponent<CharacterController>();
	}

	void Update()
	{
		if (rotateCount >= 120)
		{
			rotateCount = 0f;
			rotating = false;
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			rotating = true;
		}

		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;
		Vector3 movement = new Vector3(deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude(movement, speed);
		movement.y = gravity;
		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		charController.Move(movement);

		if (rotating == true)
		{
			Debug.Log("ROTATING");
			transform.Rotate(Vector3.left * 3);
			rotateCount++;
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.G))
			{
				if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SampleScene"))
				{
					Application.LoadLevel("SceneTwo");
				}
				else
				{
					Application.LoadLevel("SampleScene");
				}
			}

			if (Input.GetKeyDown(KeyCode.C) && cameraController != null)
			{
				if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SampleScene"))
				{
					cameraController.ChangeView();
				}
			}
		}
	}
}