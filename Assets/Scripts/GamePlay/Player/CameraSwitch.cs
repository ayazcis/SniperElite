using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{


	[Header("Cameras")]
	public CinemachineVirtualCamera fpsCam;
	public CinemachineVirtualCamera thirdpersonCam;

	public Canvas fpsCanvas;

	void Update()
	{
		if (Input.touchCount > 0 || Input.GetMouseButton(0))
		{

			SwitchCameraModeToFps(true);
		}
		else
		{
			SwitchCameraModeToFps(false);


		}


	}

	private void SwitchCameraModeToFps(bool value)
	{
		if (value)
		{
			thirdpersonCam.Priority = 10;
			fpsCam.Priority = 11;
			fpsCanvas.enabled = true;
		}
		else
		{
			thirdpersonCam.Priority = 11;
			fpsCam.Priority = 10;
			fpsCanvas.enabled = false;

		}


	}


}

