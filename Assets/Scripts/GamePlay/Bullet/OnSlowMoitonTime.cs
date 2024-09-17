using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSlowMotionTime : MonoBehaviour
{
    private List<Enemy> m_EnemyList;
    private List<float> m_SpeedList;


    public bool m_SlowMotion;


	private void Start()
	{
		m_EnemyList = new List<Enemy>(FindObjectsOfType<Enemy>());

		m_SpeedList = new List<float>();
		foreach (Enemy enemy in m_EnemyList)
		{
			m_SpeedList.Add(enemy.EnemyDataSO.moveSpeed);
		}
	}


	public void SetEnemySpeed(float speed)
    {
		foreach (Enemy enemy in m_EnemyList)
		{
			enemy.EnemyDataSO.moveSpeed = speed;
		}
	}

	public void SetBackEnemySpeed()
	{
		for (int i=0;i<m_EnemyList.Count;i++)
		{
			m_EnemyList[i].EnemyDataSO.moveSpeed = m_SpeedList[i];
		}
	}
}
