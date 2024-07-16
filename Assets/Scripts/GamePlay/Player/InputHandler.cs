using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
	private float mouseStartPosX;
	private float currentRotationY;
	private float initialRotationY;

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
			float deltaPos = Input.mousePosition.x - mouseStartPosX;
			currentRotationY -= deltaPos;

			// Ýlk rotasyondan max 35 derece saða sola dönmesini saðlamak için clamp
			currentRotationY = Mathf.Clamp(currentRotationY, initialRotationY - 35, initialRotationY + 35);

			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, -currentRotationY, transform.localEulerAngles.z);

			mouseStartPosX = Input.mousePosition.x;
		}
	}
}
