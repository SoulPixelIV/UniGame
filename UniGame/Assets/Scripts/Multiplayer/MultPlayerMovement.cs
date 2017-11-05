using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MultPlayerMovement : NetworkBehaviour {
    public int Player;
    public int dir;
    public float force;
    public float speed;
    public float forceAmount;
    public GameObject otherPlayer;

    float gravity;
    bool inField;

    Vector3 Startpos;
	// Use this for initialization
	void Start () {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        Startpos = transform.position;
	}

    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            transform.position = Startpos;
            gravity = 0;
        }
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
            if (!isServer)
                return;
            RpcRespawn();
        }

        if (other.gameObject.tag == "Barrier")
        {
            if (!isServer)
                return;
            RpcRespawn();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }

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
