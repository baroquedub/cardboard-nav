using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class MoveTo : MonoBehaviour {

	private Vector3 startingPosition;
	MoveToTarget cameraScript;
	

	void Start() {
		startingPosition = transform.localPosition;
		SetGazedAt(false);
	}
	
	public void SetGazedAt(bool gazedAt) {
		GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
	}
	
	public void Reset() {
		transform.localPosition = startingPosition;
	}
	

	
	public void MoveToObj() {

		cameraScript = Camera.main.GetComponent<MoveToTarget>();
		cameraScript.targetObject = this.gameObject.transform;

	}

//	void OnTriggerEnter (Collider other) {
//		if (other.CompareTag("MainCamera"))
//		{
//			cameraScript.onTarget = true;
//			
//		}
//	}
//	
//	void OnTriggerStay(Collider other)
//	{
//		if (other.CompareTag("MainCamera"))
//		{
//			cameraScript.onTarget = true;
//			
//		}
//	}
//	
//	void OnTriggerExit(Collider other)
//	{
//		if (other.CompareTag("MainCamera"))
//		{
//			cameraScript.onTarget = false;
//		}
//	}
}

