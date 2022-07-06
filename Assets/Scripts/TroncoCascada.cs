using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroncoCascada : MonoBehaviour
{
	

	private PolygonCollider2D _pc2d;
	public static TroncoCascada instancia;

	private void Start()
	{
		_pc2d = GetComponent<PolygonCollider2D>();
	}
	public void TroncoOff()
    {
		_pc2d.isTrigger = false;
	}
}
