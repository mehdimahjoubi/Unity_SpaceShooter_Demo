using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public float spawnPeriod = 2;
	public GameObject[] ennemies;
	Transform[] spawnLocations;

	void Awake()
	{
		spawnLocations = new Transform[transform.childCount];
		for(int i = 0; i < transform.childCount; i++)
		{
			spawnLocations[i] = transform.GetChild(i);
		}
	}

	IEnumerator Start()
	{
		while(true)
		{
			yield return new WaitForSeconds(spawnPeriod);
			var newEnnemy = ennemies[Random.Range(0, ennemies.Length)];
			var newLoc = spawnLocations[Random.Range(0, transform.childCount)];
			var e = Instantiate(newEnnemy) as GameObject;
			e.transform.position = newLoc.position;
		}
	}
}
