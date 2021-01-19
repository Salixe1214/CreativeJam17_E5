using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLogic : MonoBehaviour
{
    [Header("Level info")]
    [SerializeField] private int levelId;

    [Header("Level objects")]
    [SerializeField] private GameObject levelSpawnPoint;
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private List<GameObject> breakables;
    [SerializeField] private GameObject lockedDoor;
    [SerializeField] private PlayerDetector nextLevelDetector;

    public Action<int> OnLevelClear;
    static public Action onUnlockDoor;

    private int defeatedEnemyCount;

    private void Awake()
    {
        defeatedEnemyCount = 0;
        for (int i = 0; i < enemies.Count; i++)
        {
            DamageableEntity death = enemies[i].GetComponentInChildren<DamageableEntity>();
            death.OnDeath += OnEnemyDeath;
        }

        nextLevelDetector.OnPlayerEnter += CompleteLevel;
    }

    private void CompleteLevel(GameObject obj)
    {
        if (OnLevelClear != null) OnLevelClear.Invoke(levelId);
    }

    private void OnEnemyDeath()
    {
        defeatedEnemyCount++;
        if (defeatedEnemyCount == enemies.Count)
        {
            if(onUnlockDoor != null)
            {
                onUnlockDoor.Invoke();
            }
            lockedDoor.SetActive(false);
        }
    }

    public void ResetLevel()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].GetComponentInChildren<DamageableEntity>().Revive();
        }
        for (int i = 0; i < breakables.Count; i++)
        {
            breakables[i].GetComponentInChildren<DamageableEntity>().Revive();
            breakables[i].SetActive(true);
        }

        defeatedEnemyCount = 0;
        lockedDoor.SetActive(true);
    }

    public void SetLevelActive(bool active)
    {
        if(enemies != null)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].GetComponentInChildren<DamageableEntity>().IsAlive())
                {
                    enemies[i].SetActive(active);
                }
            }
        }

        gameObject.SetActive(active);
    }

    public Vector2 GetLevelSpawnPoint()
    {
        return levelSpawnPoint.transform.position;
    }
}
