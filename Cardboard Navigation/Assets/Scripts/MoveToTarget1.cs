using UnityEngine;
using System.Collections;

public class MoveToTarget1 : MonoBehaviour {

	public Transform targetObject;
	Quaternion targetLook;
	Vector3 targetMove;
	Vector3 targetMoveUse;
	public bool smoothDamp = true;
	public float smoothLook = 0.5f;
	public float smoothMove = 0.5f;
	public float smoothMoveDampTime = 0.5f;
	Vector3 smoothMoveVel;
	public float distFromPlayer = 5;
	public float heightFromPlayer = 3;
	public float rayHitDistanceInFront = 3;
	
	// Use this for initialization
	void Start () {
		//targetObject = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		targetMove = targetObject.position + (targetObject.rotation * new Vector3 (0, heightFromPlayer, -distFromPlayer));
		
		RaycastHit hit;
		if (Physics.Raycast (targetObject.position, targetMove - targetObject.position, out hit, Vector3.Distance (targetObject.position, targetMove))) {
			targetMoveUse = Vector3.Lerp (hit.point, targetMove, rayHitDistanceInFront);
		} else {
			targetMoveUse = targetMove;
		}
		
		
		if (!smoothDamp) {
			transform.position = Vector3.Lerp(transform.position, targetMoveUse, smoothMove * Time.deltaTime); // using Lerp to smooth
		} else {
			transform.position = Vector3.SmoothDamp (transform.position, targetMoveUse, ref smoothMoveVel, smoothMoveDampTime); // using SmoothDamp to smooth
		}
		
		targetLook = Quaternion.LookRotation (targetObject.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, targetLook, smoothLook * Time.deltaTime);
	}
}
