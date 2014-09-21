using UnityEngine;
using System.Collections;

public class EnnemyMovement : MonoBehaviour {

	public float mvt = 1;
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position, transform.position - Vector3.up, mvt * Time.deltaTime);
	}
}
