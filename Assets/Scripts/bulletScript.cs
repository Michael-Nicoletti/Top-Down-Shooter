using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {

    [SerializeField] float velocity;

	// Use this for initialization
	void Start () 
    {
        //fireBullet();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    public void fireBullet()
    {
        //Destroy(gameObject, 3);
        Vector2 force = transform.right * velocity;
        GetComponent<Rigidbody2D>().AddForce(force);
        StartCoroutine(WaitToHide());
    }

    IEnumerator WaitToHide()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
