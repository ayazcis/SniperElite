using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health=5f;
	public bool dead= false;
	public EnemyController enemyController;

	private void Update()
	{
		CheckHealth();
	}

	private void CheckHealth()
	{
		if (health <= 0)
		{
			dead = true;
		}
	}
	public void EnemyDied()
	{
		enemyController.EnemyDied(this);
	}
}
