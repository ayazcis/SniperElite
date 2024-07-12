using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
	private float mouseStartPosX;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			mouseStartPosX = Input.mousePosition.x;
		}
		if (Input.GetMouseButton(0))
		{
			float deltaPos = Input.mousePosition.x - mouseStartPosX;
			transform.localEulerAngles += new Vector3(0,-deltaPos,0);
			mouseStartPosX = Input.mousePosition.x;
		}
	}
}
