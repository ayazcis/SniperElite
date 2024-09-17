using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
	public List<StageController> stages;
	public PlayerAutoMove playerAutoMove;
	private void Start()
	{
		Cursor.visible = false;
	}
	public void Check()
	{
		playerAutoMove.ChangeTransform();
		if (IsLevelComplete())
		{
			Debug.Log("LEVEL BÝTTÝ");
			playerAutoMove.animator.SetBool("Victory", true);
			StartCoroutine(LoadNextSceneWithDelay(2f));
		}
	}

	private IEnumerator LoadNextSceneWithDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
	}

	public bool AreAllStagesComplete()
	{
		foreach (StageController stage in stages)
		{
			if (!stage.IsCompleted())
			{
				return false;
			}
		}
		return true;
	}

	public bool IsLevelComplete() => AreAllStagesComplete();
}
