using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Spell_IceRing : Weapon_Spell {

	public GameObject icicleEruptionPrefab;
	public float icicleSizeMultiplier;

	
	protected override void Attack()
	{
		base.Attack();

		Vector3 temppos = characterTrans.position;
		temppos.y -= characterTrans.GetComponent<Player>().playerCollider.height/2;
		GameObject tempIcicleGo = Instantiate(icicleEruptionPrefab, temppos, characterTrans.rotation);
		Eruption_Icicle currentIcicle = tempIcicleGo.GetComponent<Eruption_Icicle>();
		currentIcicle.layersOfEffect = layersOfEffect;
		currentIcicle.damage = damage;
		currentIcicle.destroyTime = destroyTime;
		currentIcicle.sizeMultiplier = icicleSizeMultiplier;
		currentIcicle.iceBuff = iceBuff;
		currentIcicle.stunBuff = stunBuff;
		currentIcicle.buffTime = buffTime;
		currentIcicle.Instantiate();

	}

}
