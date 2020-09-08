using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
     public UIManager uiMng;

    [Header("Knife Spawning")]
    [SerializeField] GameObject knifePrefab;
    [SerializeField] private int knifeCount;

    private WaitForSeconds secondDueToGameOverSequence = new WaitForSeconds(0.3f);

    public static GameManager gameManagerInstance { get; private set; }

    private void Awake()
    {
        if (gameManagerInstance == null) gameManagerInstance = this;
    }

    private void Start()
    {
        uiMng.SetInitialDisplayedKnifeIconCount(knifeCount);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ThrowKnife();
        }
    }

    private void ThrowKnife()
    {
        knifeCount--;
        uiMng.DecreaseDisplayedKnifeIcon();
        SpawnKnife();
    }

    private void SpawnKnife()
    {
        if (knifeCount > 0)
        {
            Vector3 knifeSpawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject instance = Instantiate(knifePrefab, knifeSpawnPos, Quaternion.identity);
            instance.transform.position += new Vector3(0, 0, 10);
        }
        else
        {
            StartGameOverSequence();
        }
    }

    public void StartGameOverSequence()
    {
        StartCoroutine("GameOverSequenceCoroutine");
    }

    private IEnumerator GameOverSequenceCoroutine()
    {
        yield return secondDueToGameOverSequence;
        uiMng.ShowLosePanel();
    }
    
    public void CheckIfTheSceneIsCompleted()//This used by Target Script (each time a target destroyed)
    {
        int countTarget=GameObject.FindObjectsOfType<Target>().Length;
        if(countTarget<=1)// This should be one,its called before the last one destroyed 
        {
            uiMng.ShowSuccessPanel();
        }
    }
    
}
