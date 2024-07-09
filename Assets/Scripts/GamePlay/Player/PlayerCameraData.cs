using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerCameraData",menuName ="CameraData")]
public class PlayerCameraData : ScriptableObject
{
	
	public float cameraRotateSensitivity = 30f;
	public float xRotation = 0f;
	public float playersDefaultRotationY = 180f;
	public float playersDefaultRotationZ = 0f;
	[Space(8)]
	[Header("Max Rotation In Y")]
	public float MaxRotationAngle = 35f;
}


   
