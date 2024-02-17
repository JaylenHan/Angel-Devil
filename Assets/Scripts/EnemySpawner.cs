using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]

    private GameObject[] enemies;

    [SerializeField]
    private GameObject boss;


    private float[] arrPosX = { -2.2f, -1.1f, 0f, 1.1f, 2.2f }; //Enemy 랜덤 스폰 위치

    [SerializeField]

    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartEnemyRoutine();
    }

    void StartEnemyRoutine() {
        StartCoroutine("EnemyRoutine"); //에너미 루틴 메소드를 코루틴으로 호출
    }

    public void StopEnemyRoutine() {
        StopCoroutine("EnemyRoutine");
    }


    IEnumerator EnemyRoutine() {
        yield return new WaitForSeconds(3f); //3초 기다림

        float moveSpeed = 5f;
        int spawnCount = 0;
        int enemyIndex = 0;

        while(true) {
        foreach(float posX in arrPosX) {
            //int index = Random.Range(0, enemies.Length); //랜덤으로 적을 뽑고
            SpawnEnemy(posX, enemyIndex, moveSpeed);
        
        }

        spawnCount += 1;
        if (spawnCount % 10 == 0) { //10, 20, 30 ,,,난이도 올리기
            enemyIndex += 1;
            moveSpeed += 2;

        }

        if (enemyIndex >= enemies.Length) {
            SpawnBoss();
            enemyIndex = 0;
            moveSpeed = 5f; //보스가 나오면 다른 적들이 다시 약하고 느려지게 바꿈

        }

        yield return new WaitForSeconds(spawnInterval);
      }
    }

    void SpawnEnemy(float posX, int index, float moveSpeed) {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z); //Enemy 랜덤 스폰 위치
        
        if (Random.Range(0, 5) == 0) { //난이도 올리기, 중간중간에 체력이 쎈 적을 확률적으로 넣음
            index += 1;
        }


        if (index >= enemies.Length){
            index = enemies.Length - 1;
        }

        GameObject enemyObject = Instantiate(enemies[index], spawnPos, Quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>(); 
        enemy.SetMoveSpeed(moveSpeed);
    }

    void SpawnBoss() {
        Instantiate(boss, transform.position, Quaternion.identity);

    }
}
