using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class LevelManager : MonoBehaviour {

	private int lives; 
	private int score; 
	private Text textLives; 
	private Text textScore; 
	private Text finalScore; 

	void Start() {
		try {
			lives = GameObject.FindObjectOfType<LoseCollider>().getLives(); 
			textLives = GameObject.Find("Lives").GetComponent<Text>();
			textScore = GameObject.Find("Score").GetComponent<Text>();  
			textLives.text = lives + ""; 
			textScore.text = "Score: " + Brick.score + " pts"; 
		} catch {
		
		}
		try {
			finalScore = GameObject.Find("FinalScore").GetComponent<Text>();	
			finalScore.text = "Score: " + Brick.finalScore + " pts";
		} catch {
		
		}
	}
	
	void Update() {
		try {
			lives = GameObject.FindObjectOfType<LoseCollider>().getLives(); 
			textLives = GameObject.Find("Lives").GetComponent<Text>();
			textScore = GameObject.Find("Score").GetComponent<Text>();  
			textLives.text = lives + ""; 
			textScore.text = "Score: " + Brick.score + " pts"; 
		} catch {
		
		}
	}

	public void LoadLevel(string name){
		Brick.score = 0; 
		Brick.breakableCount = 0; 
		Application.LoadLevel (name);
	}

	public void QuitRequest(){
		Application.Quit ();
	}
	
	public void LoadNextLevel() {
		Brick.breakableCount = 0; 
		Application.LoadLevel(Application.loadedLevel + 1); 
	}

}
