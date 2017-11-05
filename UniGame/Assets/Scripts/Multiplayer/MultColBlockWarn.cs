using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MultColBlockWarn : NetworkBehaviour {
    public GameObject ColBlock;
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
            var block = (GameObject)Instantiate(ColBlock, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            NetworkServer.Spawn(block);
            Destroy(gameObject);
            NetworkServer.Destroy(gameObject);
        }
    }
}
