using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class LoseCollider : MonoBehaviour {
	
	private static int lives = 3;
	private LevelManager levelManager; 
	
	void Start() {
		levelManager = GameObject.FindObjectOfType<LevelManager>(); 
	}

	void OnTriggerEnter2D(Collider2D trigger) {
		print ("Trigger"); 
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		lives--;
		if (lives <= 0) {
			lives = 3; 
			Brick.finalScore = Brick.score; 
			Brick.score = 0;
			levelManager.LoadLevel("Game Over"); 
		} else {
			Ball ball = GameObject.FindObjectOfType<Ball>(); 
			ball.Restart(); 
		}
		
	}
	
	public int getLives() {
		return lives; 
	}
}
