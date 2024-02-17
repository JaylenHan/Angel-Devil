using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static GameManager instance = null;

   [SerializeField]
   private TextMeshProUGUI text;

   [SerializeField]
   private GameObject gameOverPanel;





   private int coin = 0;

   [HideInInspector]

   public bool isGameOver = false;

   void Awake() {
    if (instance ==null) {
        instance = this;
    }
     
   }

   public void IncreaseCoin() {
    coin += 1;
    text.SetText(coin.ToString());

    if (coin % 20 == 0) { //30, 20, 10...코인 갯수에 따라서 무기가 더 강해짐
        Player player = FindObjectOfType<Player>();
        if (player != null) {
            player.Upgrade();
        }

     }

   }

   public void SetGameOver() {
    isGameOver = true;
    EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
    if (enemySpawner != null) {
        enemySpawner.StopEnemyRoutine();
    }

    Invoke("ShowGameOverPanel", 1f); //1초 뒤에 게임오버 패널이 보이게 하기
   }

   void ShowGameOverPanel() {
    gameOverPanel.SetActive(true);
   }

   public void PlayAgain() {
    SceneManager.LoadScene("SampleScene");

   }

}
