using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAutoMove : MonoBehaviour
{
    public LevelController levelController;
    private StageController stageController;
	public NavMeshAgent agent;
	private InputHandler _inputHandler;
	public CameraSwitch cameraSwitch;
	
	private Transform targetTransform;
    public Animator animator;


    public float moveSpeed = 5f;
	public float rotationToEnemySpeed = 2f;
	private bool _isMoving;

	private void Start()
	{
		_isMoving = true;
		_inputHandler = GetComponent<InputHandler>();

	}
	private void Update()
	{
		CrouchCheck();
		if (_isMoving)
		{
			animator.SetBool("Move", true);
			Move();
			if (transform.position.x == targetTransform.position.x && transform.position.z == targetTransform.position.z)
			{
				Debug.Log("giriyo");
				animator.SetBool("Move", false);
				_isMoving = false;
			}

		}
       
	}
	public void ChangeTransform()
    {
        animator.SetBool("Move",true);
        stageController = FindStage();
        if(stageController != null )
        {
			_isMoving = true;
		}
		
	}
	private StageController FindStage()
    {
        foreach(StageController stageController in levelController.stages)
        {
            if (!stageController.IsCompleted())
            {
                return stageController;
            }
        }
        return null;
    }

	private void Move()
	{

		stageController = FindStage();
		targetTransform = stageController.GetTransform();
		agent.SetDestination(targetTransform.position);
       
        
	}

	private void CrouchCheck()
	{
		if(_isMoving)
		{
			animator.SetBool("Crouch",false);
		}
		else if (cameraSwitch.fps)
		{
			animator.SetBool("Crouch", false);
		
		}
		else
		{
			animator.SetBool("Crouch", true);
			CrouchRotationToEnemy();
		}
	}

	private void CrouchRotationToEnemy()
	{
		if(FindAliveEnemyTransform(stageController) != null)
		{
			Vector3 direction = (FindAliveEnemyTransform(stageController).position - transform.position).normalized;
			Quaternion lookRotation = Quaternion.LookRotation(direction);
			transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationToEnemySpeed);

			_inputHandler.InitializeCurrentRotations();
		}
		
	}


	private Transform FindAliveEnemyTransform(StageController stageController)
	{
		if(stageController != null)
		{
			foreach (Enemy enemy in stageController._enemies)
			{
				if (!enemy.deadAnimOver)
				{
					return enemy.transform;
				}
			}
		}
		
		return null;
	}




}