using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceOut : MonoBehaviour {


    private bool isSpaced = false;

    public GameObject snapSpot;

    private OrginSpot Ogspot;
    private selectionController selectedCon;


	// Use this for initialization
	void Start () {
        Ogspot = GetComponent<OrginSpot>();
        selectedCon = GameObject.Find("SelectionManager").GetComponent<selectionController>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            if (isSpaced == false)
            {
                transform.position = snapSpot.transform.position;
                isSpaced = true;
            }
            else
            {
                transform.position = Ogspot.orginPostion;
                isSpaced = false;
            }
        }

	}
}
