using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private List<LevelLogic> levels;
    [SerializeField] private string gameOverSceneName;

    private int currentLevelId;

    static public Action<int> nextLevel;
    static public Action restart;

    private void Awake()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            levels[i].OnLevelClear += LevelCleared;
            levels[i].SetLevelActive(false);
        }

        player.GetComponentInChildren<DamageableEntity>().OnRevive += PlayerRevived;
        player.GetComponent<MortDuJoueur>().openShop += VoidLevels;

        // Leave the first level active tho
        levels[0].SetLevelActive(true);
    }

    private void OnEnable()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            levels[i].OnLevelClear += LevelCleared;
        }
        player.GetComponentInChildren<DamageableEntity>().OnRevive += PlayerRevived;
        player.GetComponent<MortDuJoueur>().openShop += VoidLevels;
    }

    private void OnDisable()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            levels[i].OnLevelClear -= LevelCleared;
        }

        if(player != null)
        {
            player.GetComponentInChildren<DamageableEntity>().OnRevive -= PlayerRevived;
            player.GetComponent<MortDuJoueur>().openShop -= VoidLevels;
        }
    }

    private void PlayerRevived()
    {
        ResetLevels();
    }

    public void VoidLevels()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            levels[i].SetLevelActive(false);
        }
    }

    public void ResetLevels()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            levels[i].ResetLevel();
            levels[i].SetLevelActive(false);
        }

        if (restart != null)
        {
            restart.Invoke();
        }
        // Leave the first level active tho
        levels[0].SetLevelActive(true);
    }

    private void LevelCleared(int levelId)
    {
        // If not last level
        if (levelId < levels.Count - 1)
        {
            if (nextLevel != null)
                nextLevel.Invoke(levelId + 1);
            Debug.Log("Level ID: " + levelId);
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
            SceneManager.LoadScene(gameOverSceneName);
        }
    }
}
