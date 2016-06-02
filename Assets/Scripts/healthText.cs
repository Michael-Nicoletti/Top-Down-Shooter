using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class healthText : MonoBehaviour {

    Text text;
    [SerializeField] GameObject player;

    // Use this for initialization
	void Start () {
        
        text = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {

        text.text = player.GetComponent<playerMovement>().returnHealth().ToString();

        transform.position = player.transform.position - new Vector3(0, 1, 0);

	}
}
