using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    Monster[] monsters;
    [SerializeField] string nextLevelName;
    void OnEnable() {
        monsters = FindObjectsOfType<Monster>();
    }

    // Update is called once per frame
    void Update() {
        if (MonstersAreAllDead()) GoToNextLevel();
        
    }

    bool MonstersAreAllDead() {
        for (int i = 0; i < monsters.Length; i++) {
            if (monsters[i].gameObject.activeSelf) return false;
        }
        return true;
    }

    void GoToNextLevel() {
        Debug.Log("Go to level" + nextLevelName);
        SceneManager.LoadScene(nextLevelName);
        // UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevelName);
    }
}
