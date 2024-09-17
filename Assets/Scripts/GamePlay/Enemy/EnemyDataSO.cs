using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "EnemyData")]
public class EnemyDataSO : ScriptableObject
{
	public float idleTime = 2f;
	public float moveSpeed = 5f;
	public float detectDistance = 5f;
	public float attackDistance = 3f;
	public float moveRange = 1f;

}
