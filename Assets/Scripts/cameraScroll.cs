using UnityEngine;
using System.Collections;

public class cameraScroll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {

        if(col.gameObject.tag == "Player")
        {
            transform.position += new Vector3(0, 1, 0);
        }
    }
}
