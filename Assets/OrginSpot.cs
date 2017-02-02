using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrginSpot : MonoBehaviour {

    public Vector3 orginPostion;
    public Vector3 orginRotation;



	// Use this for initialization
	void Start () {
        orginPostion = transform.position;
        orginRotation = transform.rotation.eulerAngles;
        //Debug.Log(gameObject.transform.name + " " + orginRotation);
	}
	
}
