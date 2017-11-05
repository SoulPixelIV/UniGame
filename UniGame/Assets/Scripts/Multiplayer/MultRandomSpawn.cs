﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MultRandomSpawn : NetworkBehaviour {
    public GameObject ColBlockWarn;
    public GameObject ColBlock;
    public GameObject DirChangerWarn;
    public GameObject DirChanger;
    public float timer;
    float timerSave;

    [SyncVar]
    float Varx;
    float Vary;
    float Varx2;
    float Vary2;

    // Use this for initialization
    void Start () {
        timerSave = timer;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= 1 * Time.deltaTime;

        if (timer < 0)
        {
            var dir = (GameObject)Instantiate(DirChangerWarn, new Vector3(Varx, Vary, 0), Quaternion.identity);
            var col = (GameObject)Instantiate(ColBlockWarn, new Vector3(Varx2, Vary2, 0), Quaternion.identity);
            NetworkServer.Spawn(dir);
            NetworkServer.Spawn(col);
            timer = timerSave;

            if (!isServer)
                return;
            Varx = Random.Range(-13, 13);
            Vary = Random.Range(-8, 8);
            Varx2 = Random.Range(-13, 13);
            Vary2 = Random.Range(-8, 8);
        }
	}
}