using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public List<Enemy> _enemies;
    public LevelController LevelController;
    public Transform playerShootingTransform;
    public void Check()
    {
        if (IsCompleted())
        {
            LevelController.Check();
        }
    }
    public bool AreAllEnemiesDead()
    {
        foreach (Enemy enemy in _enemies)
        {
            if (!enemy.IsDead())
            {
                return false;
            }
        }
        return true;

    }
    public Transform GetTransform()
    {
        return playerShootingTransform;
    }
    public  bool IsCompleted() => AreAllEnemiesDead();
   
}
