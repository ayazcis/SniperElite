using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Cinemachine;
using UnityEditor;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
	[Header("Cameras")]
	public CinemachineVirtualCamera fpsCam;
	public CinemachineVirtualCamera thirdpersonCam;
	[Space(8)]
	public Transform Sniper;
	[Space(8)]
	public PlayerCameraData PlayerCameraData;
	

	private void Awake()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void SwitchCameraModeToFps(bool value)
	{
		if(value)
		{
			thirdpersonCam.Priority = 10;
			fpsCam.Priority = 11;
		}
		else
		{
			thirdpersonCam.Priority = 11;
			fpsCam.Priority = 10;
		}
		
		
	}
	
    void Update()
    {
		if (Input.touchCount > 0 || Input.GetMouseButton(0))
		{
			
			SwitchCameraModeToFps(true);
			RotateCamera(true);
		}
		else
		{
			SwitchCameraModeToFps(false);
			RotateCamera(false);


		}
       
        
	}
	void RotateCamera(bool fps)
	{
		if (fps)
		{
			Vector2 inputDelta = HandleInput();
			float yaw = inputDelta.x * PlayerCameraData.cameraRotateSensitivity * Time.deltaTime;
			float pitch = inputDelta.y * PlayerCameraData.cameraRotateSensitivity * Time.deltaTime;

			PlayerCameraData.xRotation -= pitch;
			PlayerCameraData.xRotation = Mathf.Clamp(PlayerCameraData.xRotation, -PlayerCameraData.MaxRotationAngle, PlayerCameraData.MaxRotationAngle);


			Quaternion pitchRotation = Quaternion.Euler(PlayerCameraData.xRotation, PlayerCameraData.playersDefaultRotationY, PlayerCameraData.playersDefaultRotationZ);

			fpsCam.transform.localRotation = pitchRotation;
			transform.Rotate(Vector3.up * yaw);
		}
		else
		{
			float mouseX = Input.GetAxis("Mouse X") * PlayerCameraData.cameraRotateSensitivity * Time.deltaTime;
			transform.Rotate(Vector3.up * mouseX);
		}
		
	}
	public Vector2 HandleInput()
	{
		Vector2 inputDelta = Vector2.zero;
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			inputDelta = touch.deltaPosition;
		}
		else if (Input.GetMouseButton(0))
		{
			inputDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
		}
		return inputDelta;
	}

	
}
