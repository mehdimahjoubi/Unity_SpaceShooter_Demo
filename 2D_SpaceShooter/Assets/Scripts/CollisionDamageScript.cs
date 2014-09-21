using UnityEngine;
using System.Collections;

public class CollisionDamageScript : MonoBehaviour {

	public ShipScript ship;

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ennemy" || collision.gameObject.tag == "Player")
		{
			ship.ApplyCollisionDamage();
			var otherShip = collision.gameObject.GetComponent<ShipScript>();
			if (otherShip != null)
				otherShip.ApplyCollisionDamage();
		}
	}

}
