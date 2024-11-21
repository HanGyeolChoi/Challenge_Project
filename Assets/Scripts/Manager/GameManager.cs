using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private int curStage = 1;

    private Transform mapTransform;

    private List<List<GameObject>> enemyAtStage;
    private List<float> spawnRateAtStage;
    private void Start()
    {
        StartCoroutine(StartWave(curStage));
        
    }


    private IEnumerator StartWave(int stage)
    {
        yield return null;

        
    }

    private void SpawnEnemyWave(int stage)
    {
        int index = stage - 1;
        List<GameObject> enemyList = enemyAtStage[index];
        float spawnRate = spawnRateAtStage[index];


        
    }


    private IEnumerator SpawnRandomEnemy(List<GameObject> enemyList, float spawnRate)
    {
        while (true) {
            int enemyIndex = Random.Range(0, enemyList.Count);
            float scaleX = mapTransform.localScale.x;
            float scaleY = mapTransform.localScale.y;
            float posX = Random.Range(-scaleX / 2 + 2, scaleX / 2 - 2);
            float posY = Random.Range(-scaleY / 2 + 2, scaleY / 2 - 2);

            Instantiate(enemyList[enemyIndex]);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}