using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {

	Vector3 initialScale;
	public GameObject bubble;

	// Use this for initialization
	void Start () {
		initialScale = transform.localScale;
		bubble.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
		                 Camera.main.transform.rotation * Vector3.up);
		transform.localScale = initialScale + Vector3.up * Mathf.Sin(Time.time) * 0.05f + Vector3.right * Mathf.Cos(Time.time) * 0.05f;
		
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player")
		{
			bubble.SetActive(true);
			Debug.Log("trigger!");
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if (collider.tag == "Player")
		{
			bubble.SetActive(false);
			Debug.Log("no trigger!");
		}
	}
}
