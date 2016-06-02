using UnityEngine;
using System.Collections;

public class tankFireScript : MonoBehaviour {

    private objectPool oP;
    private float timeToFire;

	// Use this for initialization
	void Start () {

        oP = GetComponent<objectPool>();
	
	}
	
	// Update is called once per frame
	void Update () {

        timeToFire--;
	
	}

    public void aimCannon(GameObject player)
    {
        Vector3 pos = transform.position;
        Vector3 dir = player.transform.position - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void fireCannon()
    {
        if(timeToFire <= 0)
        {
            GameObject temp = oP.GetFromPool();

            temp.SetActive(true);
            temp.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            temp.transform.rotation = transform.rotation;
            temp.GetComponent<bulletScript>().fireBullet();
            timeToFire = 60;
        }
        
    }
}
