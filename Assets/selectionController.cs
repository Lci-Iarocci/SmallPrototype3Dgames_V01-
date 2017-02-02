using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectionController : MonoBehaviour
{

    public GameObject[] allPeices;
    public int currentPeice = 0;

    private bool isSpaced = false;

    public string Horizontal;
    public string spaceOutbutton;
    public string rotateButton;

    public Material orginalMaterial;
    public Material newMaterial;

    private bool isDelayed = false;

    private Vector3 currentAngle;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(spaceOutbutton))
        {
            if (isSpaced == false)
            {
                allPeices[currentPeice].GetComponent<Renderer>().material = newMaterial;
                isSpaced = true;
            }
            else
            {
                allPeices[currentPeice].GetComponent<Renderer>().material = orginalMaterial;
                isSpaced = false;
            }
        }

        if (isDelayed == false && isSpaced == true)
        {
            HighlightSelected();
            RotateSelected();
        }

    }

    void RotateSelected()
    {
        if (Input.GetButtonDown(rotateButton))
        {
            currentAngle.y += 90;
            if (currentAngle.y > 360)
            {
                currentAngle.y = 90;
            }

            allPeices[currentPeice].transform.rotation = Quaternion.Euler(currentAngle);
            
        }

    }

    void HighlightSelected()
    {
        if (Input.GetAxisRaw(Horizontal) > 0)
        {
            isDelayed = true;

            allPeices[currentPeice].GetComponent<Renderer>().material = orginalMaterial;
            currentPeice += 1;
            if (currentPeice > 3)
            {
                currentPeice = 0;
            }
            allPeices[currentPeice].GetComponent<Renderer>().material = newMaterial;
            currentAngle = allPeices[currentPeice].transform.rotation.eulerAngles;

            StartCoroutine(Delay());
        }
        else if (Input.GetAxisRaw(Horizontal) < 0)
        {
            isDelayed = true;

            allPeices[currentPeice].GetComponent<Renderer>().material = orginalMaterial;
            currentPeice -= 1;
            if (currentPeice < 0)
            {
                currentPeice = 3;
            }
            allPeices[currentPeice].GetComponent<Renderer>().material = newMaterial;
            currentAngle = allPeices[currentPeice].transform.rotation.eulerAngles;

            StartCoroutine(Delay());
        }



    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(.15f);
        isDelayed = false;
    }
}
