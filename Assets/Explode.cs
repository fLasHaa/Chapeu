using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {
	public GameObject Explosion;
	public ParticleSystem[] effects;

	[SerializeField] private float damage;

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			collision.GetComponent<Health>().TakeDamage(damage);
		}
	}


	void OnCollisionEnter2D (Collision2D collision){
		Instantiate (Explosion, transform.position, transform.rotation);
		foreach (var effect in effects) {
			effect.transform.parent = null;
			effect.Stop ();
			Destroy (effect.gameObject, 2.0f);
		}
		Destroy (gameObject);

	}



}
