using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
	Check all affected enemies here
	Then create lightning visuals and deal damage on enemies

 */


public class Weapon_Spell_Lightning : Weapon_Spell {

	[Tooltip("Amount of enemies the lightning can affect")]
	public int hops;
	[Tooltip("Radius check if unaffected enemies nearby")]
	public float hopRadius;
	[Range(0.05f,10f), Tooltip("How much hopRadius should decrease after each hop. 1 means not at all."),]
	public float effectArea;
	public float radiusMultiplier;
	public LineRenderer linerenderer;

	// Use this for initialization
	void Start () {
		
	}
	
	protected override void Attack()
	{
		base.Attack();


		List<Collider> hits = new List<Collider>();
		//Check all affected enemies with sphere checks
		// RaycastHit hit;


		RaycastHit[] playerHits = Physics.SphereCastAll(playerTrans.position, effectArea, playerTrans.forward, hopRadius, layersOfEffect);
		foreach(RaycastHit hit in playerHits)
		{
			if (!hits.Contains(hit.collider))
			{
				//Draw lightning line between player & spherehit
				var points = new Vector3[2];
				points[0] = playerTrans.position;
				points[1] = hit.collider.transform.position;

				var line = Instantiate(linerenderer, playerTrans.position, playerTrans.rotation);
				line.SetPositions(points);
				Destroy(line.gameObject, 0.1f);
				//Deal damage to spherehit
				Enemy enemy = hit.collider.GetComponentInChildren<Enemy>();
				if (!enemy)
					enemy = hit.collider.GetComponentInParent<Enemy>();
				if (enemy)
				{
					enemy.AddBuff(iceBuff, stunBuff, buffTime);
					enemy.GetHit(damage);
				}

				hits.Add(hit.collider);

			}
		}

		float tempradius = hopRadius;

		for(int i = 0; i < hops; i++)
		{
			tempradius *=radiusMultiplier;
			// foreach (Collider spherehit in hits)
			int forCount = hits.Count;
			for(int j = 0; i < forCount; i++)
			{
				Collider[] enemyHits = Physics.OverlapSphere(hits[j].transform.position, tempradius, layersOfEffect);
				foreach(Collider spherehit2 in enemyHits)
				{
					if (!hits.Contains(spherehit2))
					{
						Vector3[] points = new Vector3[2];
						points[0] = hits[j].transform.position;
						points[1] = spherehit2.transform.position;
						LineRenderer line = Instantiate(linerenderer, playerTrans.position, playerTrans.rotation);
						line.SetPositions(points);
						Destroy(line.gameObject, 0.1f);

						Enemy enemy = spherehit2.GetComponentInChildren<Enemy>();
						if (!enemy)
							enemy = spherehit2.GetComponentInParent<Enemy>();
						enemy.AddBuff(iceBuff, stunBuff, buffTime);
						enemy.GetHit(damage);
						hits.Add(spherehit2);

					}
				}
				forCount = hits.Count;
			}
		}

		
		if (hits.Count == 0)
		{
			Vector3[] points = new Vector3[2];
			points[0] = playerTrans.position;
			points[1] = playerTrans.forward* hopRadius + playerTrans.position;
			LineRenderer line = Instantiate(linerenderer, playerTrans.position, playerTrans.rotation);
			line.SetPositions(points);
			Destroy(line.gameObject, 0.1f);
		
		}
	}
}
