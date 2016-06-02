using UnityEngine;
using System.Collections;

public class areaRemover : MonoBehaviour {

    [SerializeField] GameObject areaToTurnOff;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            areaToTurnOff.SetActive(false);
        }
    }
}
