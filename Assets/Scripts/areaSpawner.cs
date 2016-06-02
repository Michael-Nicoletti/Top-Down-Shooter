using UnityEngine;
using System.Collections;

public class areaSpawner : MonoBehaviour {

    [SerializeField] GameObject areaToTurnOn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            areaToTurnOn.SetActive(true);
        }
    }
}
