using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject   foodContainer;
    public GameObject   waterContainer;
    // public float        waterCount;
    // public float        foodCount;
    public float        timerScore;
    private int         score;
    public bool         gameOver;
    private bool        isNegative;
    private bool        timerAvaliable;
    private string      boxString;

    void Awake() {
        score = 0;
        gameOver = false;
    }
    void FixedUpdate() {
        if (!gameOver) {
            GameOverCondition();
            boxString = "Score: " + score;
        }
        
        ResetGame ();
        
    }

    void GameOverCondition () {
        if (isNegative) {
            timerScore -= 1 * Time.deltaTime;
            timerAvaliable = true;
        } else {
            timerScore = 10;
        }
                
        isNegative = score < 0;

        if (timerScore <= 0) gameOver = true;;
        if (timerScore < 0) timerAvaliable = false; 

        Debug.Log(timerScore);
    }

    void ResetGame () {
        if (Input.GetKey(KeyCode.Space)) {	
            Time.timeScale = 1;		
			SceneManager.LoadScene("Main");	
		}
    }

    public void AddScore (int qtd) {
        score += qtd;
    }
    
    void OnGUI() {
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height),boxString);

        if (timerScore < 0) {
            GUI.Box(new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), 
            "Você desperdiçou muitos recursos!\nPressione Espaço para jogar Novamente");
        }
        if (timerAvaliable) {
            if (isNegative) {
                GUI.Box(new Rect(Screen.width/4, Screen.height/6, Screen.width/2, Screen.height/2), 
                "Recupere o Score em: " + timerScore);
            }   
        }
    }
}