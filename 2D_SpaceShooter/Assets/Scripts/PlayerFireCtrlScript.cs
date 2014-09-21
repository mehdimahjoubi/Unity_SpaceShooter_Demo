using UnityEngine;
using System.Collections;

public class PlayerFireCtrlScript : MonoBehaviour {

	public ParticleSystem leftGun;
	public ParticleSystem rightGun;
	public bool autoAttack;
	bool isAttacking = false;

	void Awake()
	{
		leftGun.enableEmission = false;
		rightGun.enableEmission = false;
	}

	void Update()
	{
		if (!autoAttack)
		{
			if ((!isAttacking && Input.GetButton("Jump")) || (isAttacking && !Input.GetButton("Jump")))
				ToggleGuns();
		}
		else if (!isAttacking)
		{
			leftGun.enableEmission = true;
			rightGun.enableEmission = true;
			isAttacking = true;
		}
		if (Input.GetKeyUp(KeyCode.A))
			autoAttack = !autoAttack;
	}

	void ToggleGuns()
	{
		isAttacking = !isAttacking;
		leftGun.enableEmission = isAttacking;
		rightGun.enableEmission = isAttacking;
	}
}
