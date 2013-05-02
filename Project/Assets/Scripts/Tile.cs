using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public GameObject visuals;
	public float z;
	
	public enum Type{fox, box, environemnt};
	public Type type;
	
	public void Setup(Vector3 pos)
	{
		pos.z = z;
		this.transform.position = pos;
	}
}
