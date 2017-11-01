using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBorderScript : MonoBehaviour {
    public int Border;
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Border == 0)
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        if (Border == 1)
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
    }
}
