﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MultDirChangerWarn : NetworkBehaviour {
    public GameObject DirChanger;
    public float timer;
    float timerSave;
    // Use this for initialization
    void Start () {
        timerSave = timer;
    }
	
	// Update is called once per frame
	void Update () {
        timer -= 1 * Time.deltaTime;

        if (timer < 0)
        {
            var changer = (GameObject)Instantiate(DirChanger, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            NetworkServer.Spawn(changer);
            Destroy(gameObject);
            NetworkServer.Destroy(gameObject);
        }
    }
}
