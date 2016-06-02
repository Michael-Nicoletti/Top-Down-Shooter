using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameEndStat : MonoBehaviour {

    Text text;

	// Use this for initialization
	void Start () {

        text = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {

        if (gameStats.checkHowGameEnded())
        {
            text.text = "Game Over";
        }
        else
            text.text = "Game Win";

        if(Input.GetButtonDown("Fire1"))
        {
            Application.LoadLevel(0);
        }
	}
}
