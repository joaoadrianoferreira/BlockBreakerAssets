using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public Sprite[] hitSprites;
	private int timesHits; 
	private LevelManager levelMangeger; 
	public static int breakableCount = 0; 
	public static int score = 0; 
	public static int finalScore = 0;  
	private bool isBreakable; 
	public AudioClip crack; 
	public GameObject smoke;  
 
	void Start () {
		if (this.tag == "Breakable") {
			isBreakable = true; 
			breakableCount++; 
		} else {
			isBreakable = false; 
		}
		timesHits = 0; 
		levelMangeger = GameObject.FindObjectOfType<LevelManager>(); 
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		if (isBreakable) {
			float volume = 0.1f; 
			AudioSource.PlayClipAtPoint(crack, transform.position, volume); 
			timesHits ++;
			score = score + 10; 
			int maxHits = hitSprites.Length + 1;  
			if (timesHits >= maxHits) {
				breakableCount--; 
				GameObject smokePuff = Instantiate (smoke, gameObject.transform.position, Quaternion.identity) as GameObject; 
				smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color; 
				Destroy(gameObject); 
				if (breakableCount <= 0) {
					levelMangeger.LoadNextLevel(); 
					Brick.finalScore = score; 	
				}	
			} else {
				LoadSprites(); 
			}
		}
	}
	
	void LoadSprites() {
		int SpriteIndex = timesHits - 1; 
		if (hitSprites[SpriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[SpriteIndex];  
		} else {
			Debug.LogError("Bricks Sprite Missing!"); 
		}
	}
}
