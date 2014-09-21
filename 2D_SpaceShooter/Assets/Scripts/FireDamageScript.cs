using UnityEngine;
using System.Collections;

public class FireDamageScript : MonoBehaviour {

	public ShipScript ship;

	void OnParticleCollision(GameObject other) {
		var ps = other.GetComponent<ParticleSystem>();
		if (ps != null && ps.transform.parent != null)
		{
			var otherShip = ps.transform.parent.gameObject.GetComponent<ShipScript>();
			if (otherShip != null)
				ship.ApplyFireDamage(otherShip);
		}
	}

}
