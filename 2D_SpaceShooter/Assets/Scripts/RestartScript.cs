using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUIText))]
public class RestartScript : MonoBehaviour {

	void Update()
	{
		if (Input.GetMouseButtonDown(0) && guiText.HitTest(Input.mousePosition))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}

}
