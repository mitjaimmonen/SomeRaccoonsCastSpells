using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float destroyTime;
	public float range;
	public float damage;
	public float speed;
	public float sizeMultiplier;
	public LayerMask layersOfEffect;
	public GameObject destroyEffectParticles;
	public float destroyEffectMultiplier;
	public bool iceBuff = false, stunBuff = false;
	public float buffTime;
	[FMODUnity.EventRef, Tooltip("When projectile collides with enemy.")] public string projectileHitSound;


	private GameObject particleSystemGo;

	private Vector3 startPos;
	private float distance;
	private float destroyTimer = 0;

	void Start()
	{
		particleSystemGo = GetComponentInChildren<ParticleSystem>().gameObject;
		startPos = transform.position;
		destroyTimer = Time.time;
		gameObject.transform.localScale *= sizeMultiplier;
		particleSystemGo.transform.localScale *= sizeMultiplier;
	}

	void Update()
	{
		distance = (transform.position - startPos).magnitude;
		if ((distance > range && range != 0) || (destroyTimer < Time.time - destroyTime && destroyTime != 0))
		{
			DestroyProjectile();
		}

		transform.position += transform.forward * speed * Time.deltaTime;
	}

	protected virtual void OnCollisionEnter(Collision other)
	{
		//Deal damage
		Character enemy = other.gameObject.GetComponentInChildren<Character>();
		if (!enemy)
			enemy = other.gameObject.GetComponentInParent<Character>();
		if (enemy)
		{
			FMODUnity.RuntimeManager.PlayOneShot(projectileHitSound, enemy.transform.position);
			enemy.AddBuff(iceBuff, stunBuff, buffTime);
			enemy.GetHit(damage);
			DestroyProjectile();
		}

	}

	protected virtual void DestroyProjectile()
	{
		if (destroyEffectParticles)
		{
			GameObject temp = Instantiate(destroyEffectParticles, transform.position, transform.rotation).gameObject;
			temp.transform.localScale *= destroyEffectMultiplier;
			Destroy(temp, 1f);
		}

		Destroy(gameObject);
	}

}
