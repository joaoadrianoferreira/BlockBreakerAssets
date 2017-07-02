using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false; 
	private Ball ball; 
	
	void Start() {
		ball = GameObject.FindObjectOfType<Ball>(); 
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			moveWithMouse(); 
		} else {
			AutoPlay(); 
		}
	}
	
	void moveWithMouse() {
		Vector3 paddlePos = new Vector3(0.5f, 1f, 3f); 
		float mousePosInBlock = Input.mousePosition.x / Screen.width * 16; 
		paddlePos.x = Mathf.Clamp(mousePosInBlock, 0.5f, 15.5f); 
		this.transform.position = paddlePos; 
	}
	
	void AutoPlay() {
		Vector3 paddlePos = new Vector3(0.5f, 1f, 3f); 
		Vector3 ballPosicion = ball.transform.position; 
		paddlePos.x = Mathf.Clamp(ballPosicion.x, 0.5f, 15.5f); 
		this.transform.position = paddlePos; 
	}
}
