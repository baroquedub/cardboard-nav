using UnityEngine;
using System.Collections;

public class MoveToTarget : MonoBehaviour {


	public Transform targetObject;

	Quaternion targetLook;
	Vector3 targetMove;

	private bool onTarget = true;

	public bool smoothDamp = true;
	public float smoothLook = 0.5f;
	public float smoothMove = 0.5f;
	public float smoothMoveDampTime = 0.5f;
	Vector3 smoothMoveVel;
	public float distFromPlayer = 2;
	public float heightFromPlayer = 0;
	public float rayHitDistanceInFront = 3;
	
	// Use this for initialization
	void Start () {
		//targetObject = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {

		targetMove = targetObject.position + (targetObject.rotation * new Vector3 (0, heightFromPlayer, -distFromPlayer));
		targetLook = Quaternion.LookRotation (targetObject.position - transform.position);

		float roughPos = Mathf.Round(targetMove.y * 100f) / 100f;
		float currentPos = Mathf.Round (targetObject.position.y * 10f) / 10f;
		Debug.Log (roughPos +" || "+currentPos);
		if (roughPos < Mathf.Round (targetObject.position.y * 10f) / 10f) {
			onTarget = true;
			Debug.Log (onTarget);
		} else {
			onTarget = false;
		}

		if (!onTarget) {


				
				if (!smoothDamp) {
				transform.position = Vector3.Lerp (transform.position, targetMove, smoothMove * Time.deltaTime); // using Lerp to smooth
			} else {
				transform.position = Vector3.SmoothDamp (transform.position, targetMove, ref smoothMoveVel, smoothMoveDampTime); // using SmoothDamp to smooth
			}
		

			transform.rotation = Quaternion.Slerp (transform.rotation, targetLook, smoothLook * Time.deltaTime);

		} else {
			// set to  exact
			transform.position = targetMove;
			transform.rotation = targetLook;
		}
	}
}
