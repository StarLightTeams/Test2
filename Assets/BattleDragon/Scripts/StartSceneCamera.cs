using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneCamera : MonoBehaviour {

    public GameObject maincamera;
    private double speed = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        speed -= 0.01;
        if (speed <= 0)
        {
            maincamera.SetActive(true);
            GameObject.Find("MMCamera").SetActive(false);
        }
    }
}
