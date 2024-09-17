using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private CapsuleCollider capsuleCollider;
    public StageController _stageController;
    public float health = 5f;
    public bool deadAnimOver;
    public ParticleSystem ParticleSystem;

    public EnemyDataSO EnemyDataSO;

	private void Start()
	{
		capsuleCollider = GetComponent<CapsuleCollider>();
	}
	public void TakeDamage(float damage)
    {
        health -= damage;
        if(IsDead())
        {
            _stageController.Check();
        }
    }

    public bool IsDead() => health <= 0;

    public void DeadAnimOver()
    {
        capsuleCollider.enabled = false;    
        deadAnimOver = true;

    }
    public void Bleed()
    {
        ParticleSystem.transform.position = transform.position + new  Vector3(0,2f,0);
        ParticleSystem.Play();
    }
}
