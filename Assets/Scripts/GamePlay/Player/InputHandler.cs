using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
	public Transform fpsFollow;

	private float _mouseStartPosX;
	private float _mouseStartPosY;
	private float _currentRotationY;
	private float _initialRotationY;
	private float _initialRotationX;
	private float _currentRotationX;

	public float rotationSpeed = 0.1f;

	private float _deltaPosVertical;
	private float _deltaPosHorizontal;
	private void Start()
	{
		InitializeCurrentRotations();
	}
	public void InitializeCurrentRotations()
	{
		_initialRotationY = -transform.localEulerAngles.y;
		_currentRotationY = _initialRotationY;
		_initialRotationX = fpsFollow.localEulerAngles.x;
		_currentRotationX = _initialRotationX;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{

			_mouseStartPosX = Input.mousePosition.x;
			_mouseStartPosY = Input.mousePosition.y;

		}
		if (Input.GetMouseButton(0))
		{
			_deltaPosVertical = (Input.mousePosition.x - _mouseStartPosX) * rotationSpeed;
			_deltaPosHorizontal = (Input.mousePosition.y - _mouseStartPosY) * rotationSpeed;
			_currentRotationY -= _deltaPosVertical;
			_currentRotationX -= _deltaPosHorizontal;


			_currentRotationY = Mathf.Clamp(_currentRotationY, _initialRotationY - 40, _initialRotationY + 40);
			_currentRotationX = Mathf.Clamp(_currentRotationX, _initialRotationX-15, _initialRotationX + 15);

			transform.localEulerAngles = new Vector3(transform.localEulerAngles.z,- _currentRotationY, transform.localEulerAngles.z);
			fpsFollow.localEulerAngles= new Vector3( _currentRotationX, fpsFollow.localEulerAngles.y, fpsFollow.localEulerAngles.z);

			_mouseStartPosX = Input.mousePosition.x;
			_mouseStartPosY = Input.mousePosition.y;
		}
		if (Input.GetMouseButtonUp(0))
		{
			_initialRotationY = _currentRotationY;
			
			_initialRotationX = 0f;

		}
	}
}
