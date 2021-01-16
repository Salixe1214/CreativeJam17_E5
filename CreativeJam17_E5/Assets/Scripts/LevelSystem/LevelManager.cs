using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private List<LevelLogic> levels;

    private int currentLevelId;

    private void Awake()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            levels[i].OnLevelClear += LevelCleared;
            levels[i].SetLevelActive(false);
        }

        player.GetComponentInChildren<DamageableEntity>().OnRevive += PlayerRevived;

        // Leave the first level active tho
        levels[0].SetLevelActive(true);
    }

    private void PlayerRevived()
    {
        ResetLevels();
    }

    public void ResetLevels()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            levels[i].ResetLevel();
            levels[i].SetLevelActive(false);
        }

        // Leave the first level active tho
        levels[0].SetLevelActive(true);
    }

    private void LevelCleared(int levelId)
    {
        // If not last level
        if (levelId < levels.Count - 1)
        {
            // Activate next level
            levels[levelId].SetLevelActive(false);
            levels[levelId + 1].SetLevelActive(true);

            // TP player
            player.transform.position = levels[levelId + 1].GetLevelSpawnPoint();
        }
        // Congrats you beat the game
        else
        {
            // End game!
            Debug.Log("DADADADA!!!!");
        }
    }
}
