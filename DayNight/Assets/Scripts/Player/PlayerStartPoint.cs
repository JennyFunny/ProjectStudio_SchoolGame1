using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

    private PlayerMovement thePlayer;
   // private CameraController theCamera;

    public string pointName;

	// Use this for initialization
	void Awake () {
        thePlayer = FindObjectOfType<PlayerMovement>();

        if (thePlayer.startPoint == pointName)
        {


            thePlayer.transform.position = transform.position;

           // theCamera = FindObjectOfType<CameraController>();
           // theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }
	}
}
