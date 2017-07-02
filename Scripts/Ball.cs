using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle; 	
	private Vector3 paddleToBallVector; 
	private bool hasStarted = false; 

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position; 
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector; 
					
			if (Input.GetMouseButtonDown(0)) {
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f); 
				hasStarted = true; 
			}
		}
	}
	
	public void Restart() {
		this.GetComponent<Rigidbody2D>().velocity = new Vector2 (0f, 0f); 
		this.transform.position = new Vector3 (8f,1.261f,0f); 
		paddle.transform.position = new Vector3 (8f,1f,0f); 
		hasStarted = false; 
	} 
	
	void OnCollisionEnter2D(Collision2D collision) { 
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f)); 
		if (hasStarted) {
			GetComponent<AudioSource>().Play();
		    GetComponent<Rigidbody2D>().velocity += tweak;  
		}	
	}
}
