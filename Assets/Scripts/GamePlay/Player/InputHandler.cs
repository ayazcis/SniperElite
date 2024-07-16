using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
	private float mouseStartPosX;
	private float currentRotationY;
	private float initialRotationY;
	float deltaPos;

	private void Start()
	{
		initialRotationY = transform.localEulerAngles.y;
		currentRotationY = initialRotationY;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{

			mouseStartPosX = Input.mousePosition.x;

		}
		if (Input.GetMouseButton(0))
		{
			deltaPos = Input.mousePosition.x - mouseStartPosX;
			currentRotationY -= deltaPos;


			currentRotationY = Mathf.Clamp(currentRotationY, initialRotationY - 35, initialRotationY + 35);

			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, -currentRotationY, transform.localEulerAngles.z);

			mouseStartPosX = Input.mousePosition.x;
		}
		if (Input.GetMouseButtonUp(0))
		{
			initialRotationY = currentRotationY;
			Debug.Log("deðiþti y  " + transform.localEulerAngles.y);

		}
	}
}
