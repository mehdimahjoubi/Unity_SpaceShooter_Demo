using UnityEngine;
using System.Collections;

public class ShipScript : MonoBehaviour {

	public int LP = 100;
	public int collisionDamage = 100;
	public int firePower = 10;
	public int scoreIncrementation = 10;
	public GameObject explosionEffect;
	public GUIText lifePointsDisplay;
	public GUIText scoreDisplay;
	public GUIText restartGUI;
	static GUIText scoreGUIText;
	static int score;
	static string scoreLabel;
	string lifePointsLabel;

	void Awake()
	{
		if (lifePointsDisplay != null)
		{
			lifePointsLabel = lifePointsDisplay.text;
			lifePointsDisplay.text = lifePointsLabel + LP;
		}
		if (scoreGUIText == null && scoreDisplay != null)
		{
			scoreGUIText = scoreDisplay;
			scoreLabel = scoreGUIText.text;
			scoreGUIText.text = scoreLabel + score;
		}
	}

	public void ApplyCollisionDamage() {
		LP -= collisionDamage;
		if(lifePointsDisplay != null)
			lifePointsDisplay.text = lifePointsLabel + LP;
		if (LP <= 0)
			explode();
	}

	public void ApplyFireDamage(ShipScript otherShip){
		LP -= otherShip.firePower;
		if(lifePointsDisplay != null)
			lifePointsDisplay.text = lifePointsLabel + LP;
		if (LP <= 0)
			explode();
	}

	void explode()
	{
		LP = 0;
		if(lifePointsDisplay != null)
			lifePointsDisplay.text = lifePointsLabel + LP;
		if (explosionEffect != null)
		{
			explosionEffect.SetActive(true);
			explosionEffect.transform.parent = null;
		}
		if(gameObject.tag == "Ennemy")
		{
			score += scoreIncrementation;
			scoreGUIText.text = scoreLabel + score;
		}
		if(gameObject.tag == "Player")
			restartGUI.gameObject.SetActive(true);
		Destroy(gameObject);
	}
}
