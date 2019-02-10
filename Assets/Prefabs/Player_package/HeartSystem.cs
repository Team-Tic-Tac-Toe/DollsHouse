using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class HeartSystem : MonoBehaviour {

	public static HeartSystem instance; // HearthSystem instance static 변수

	private int maxHeartAmount = 5;
	public int startHearts = 3;
	public int currentHealth;
	private int maxHealth;
	private int healthPerHeart=2;
	
	public Image[] healthImages;
	public Sprite[] healthSprites;

	public bool ifattacked = false;

	// Use this for initialization
	void Awake(){
		instance = this;
	}

	void Start () {
		currentHealth = startHearts * healthPerHeart;
		maxHealth = maxHeartAmount * healthPerHeart;
		checkHealthAmount();
	}

	void getAttacked(){
		if(ifattacked){
			TakeDamage(-1);
		}
	}

	void checkHealthAmount(){
		for(int i=0; i< maxHeartAmount; i++){
			if(startHearts <= i){
				healthImages[i].enabled = false;
			}
			else{
				healthImages[i].enabled = true;
			}
		}
		UpdateHearts();
	}

	void UpdateHearts(){
		bool empty = false;
		int i = 0;
		foreach(Image image in healthImages){
			if(empty){
				image.sprite = healthSprites[0];
			}
			else{
				i++;
				if(currentHealth >= i * healthPerHeart)
				{
					image.sprite = healthSprites[healthSprites.Length-1];
				}
				else{
					int currentHearthHealth = (int)(healthPerHeart - (healthPerHeart * i-currentHealth));
					int healthPerImage = healthPerHeart / (healthSprites.Length -1);
					int imageIndex = currentHearthHealth / healthPerImage;
					image.sprite = healthSprites[imageIndex];
					empty = true;
				}
			}
		}
	}

	public void TakeDamage(int amount){
		currentHealth += amount;
		currentHealth = Mathf.Clamp(currentHealth,0,startHearts*healthPerHeart);
		UpdateHearts();
	}

	public void AddHeartContainer(){
		startHearts ++;
		startHearts = Mathf.Clamp(startHearts, 0, maxHeartAmount);
		
		//currentHealth = startHearts * healthPerHeart;
		//maxHealth = maxHeartAmount * healthPerHeart;

		checkHealthAmount();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F4)){
			ifattacked =true ;
			TakeDamage(-1);
		}
		if(Input.GetKeyDown(KeyCode.F5)){
			TakeDamage(1);
		}
		
	}
}
