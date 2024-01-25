using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefab;
    public Transform spawnPoint;
    public int selectedCharacter;
    void Start()
    {
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
    }

  
    public void SpawnBall()
    {
        if (!GameManager.instance.gameStarted && GameManager.instance.canSpawn)
        {
            GameObject prefab = characterPrefab[selectedCharacter];
            Instantiate(prefab, spawnPoint.transform.position, Quaternion.identity);
            GameManager.instance.gameStarted = true;
            GameManager.instance.canSpawn = false;
        }
    }
}
