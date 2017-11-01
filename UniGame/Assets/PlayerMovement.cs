using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public int Player;
    public int dir;
    public float force;
	// Use this for initialization
	void Start () {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DirChanger")
        {
            if (dir == 0)
            {
                dir = 1;
                Destroy(other.gameObject);
            }
            else
            {
                dir = 0;
                Destroy(other.gameObject);
            }
        }

        if (other.gameObject.tag == "ColBlock")
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (other.gameObject.tag == "Barrier")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
	
	// Update is called once per frame
	void Update () {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        if (dir == 1)
        {
            rb.AddForce(new Vector3(force, 0, 0));
        }
        if (dir == 0)
        {
            rb.AddForce(new Vector3(-force, 0, 0));
        }

        if (Player == 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(new Vector3(0,0.05f,0));
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(new Vector3(0, -0.05f, 0));
            }
        }
        if (Player == 1)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(new Vector3(0, 0.05f, 0));
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(new Vector3(0, -0.05f, 0));
            }
        }
    }
}
