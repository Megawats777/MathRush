using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBase : MonoBehaviour
{
	[SerializeField]
	protected int playerId = 0;


	public int getPlayerId()
	{
		return playerId;
	}
}
