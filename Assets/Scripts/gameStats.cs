using UnityEngine;
using System.Collections;

public class gameStats : MonoBehaviour {

    public static int score;
    private static bool died;

	// Use this for initialization
	void Start () {

        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void addScore(int amount)
    {
        score += amount; 
    }

    public static void setDead()
    {
        died = true;
    }

    public static bool checkHowGameEnded()
    {
        return died;
    }

    public static int checkScore()
    {
        return score;
    }
}
