using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
	[SerializeField]
	Transform startPoint;
	public void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log("triggered");
		col.gameObject.transform.position = startPoint.position;
	}
}
