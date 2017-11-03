using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public int Player;
    public int dir;
    public float force;
    public float speed;
    public float forceAmount;
    public GameObject otherPlayer;

    float gravity;
    bool inField;
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
        transform.Translate(new Vector3(gravity * Time.deltaTime, 0, 0));
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        float dist = Vector3.Distance(transform.position, otherPlayer.transform.position);
        if (dist < 2.9f)
        {
            rb.isKinematic = false;
            Vector3 direction = (transform.position - otherPlayer.transform.position).normalized;
            rb.AddForce(direction * forceAmount);
            inField = true;
        }
        
        if (dist > 4)
        {
            rb.isKinematic = true;
            inField = false;
        }

        if (dir == 1)
        {
            if (inField == false)
            {
                gravity -= 0.8f * Time.deltaTime;
            }
            else
            {
                gravity += 0.2f * Time.deltaTime;
            }
        }
        if (dir == 0)
        {
            if (inField == false)
            {
                gravity += 0.8f * Time.deltaTime;
            }
            else
            {
                gravity -= 0.2f * Time.deltaTime;
            }
        }

        if (Player == 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
            }
        }
        if (Player == 1)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
            }
        }
    }
}
