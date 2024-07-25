using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	[SerializeField]
	private List<EnemyHealth> enemies = new List<EnemyHealth>();

	private void Start()
	{
		
	}
	private void Update()
	{
		if (AreAllEnemiesDead(enemies))
			Debug.Log("tüm enemyler öldü!");
	}

	public void EnemyDied( EnemyHealth enemy )
	{
		enemies.Remove(enemy);
	}

	private bool AreAllEnemiesDead(List<EnemyHealth> enemies)
	{
		if(enemies.Count == 0) 
			return true;
		else
			return false;
	}
}
