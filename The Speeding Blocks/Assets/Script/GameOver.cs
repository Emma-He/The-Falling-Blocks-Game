using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public GameObject gameOverScreen;
	public Text secondsSurvivedUI;
    public Text highScore; 
  
	bool gameOver;

	void Start() {
        //highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
		FindObjectOfType<PlayerController> ().OnPlayerDeath += OnGameOver;
	}

	void Update () {
		if (gameOver) {
			PlayerController.resetCount();
			if (Input.GetKeyDown (KeyCode.Space)) {
				SceneManager.LoadScene (1);				
			}
            highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
		}
	}

	void OnGameOver() {
		gameOverScreen.SetActive (true);
		secondsSurvivedUI.text = (Mathf.RoundToInt(Time.timeSinceLevelLoad)+PlayerController.getCount()*10).ToString();

        int number = Mathf.RoundToInt(Time.timeSinceLevelLoad)+PlayerController.getCount()*10;

        if(number > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", number);
            highScore.text = number.ToString();
        }
		gameOver = true;
		
	}

    void Reset()
    {
        PlayerPrefs.DeleteAll();
        highScore.text = "0";
    }
}