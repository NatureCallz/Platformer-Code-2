using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour {

    public float distance = 1f;
    PlayerController movement;

	// Use this for initialization
	void Start () {
        movement = GetComponent<PlayerController>();
		
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);

        if(Input.GetButtonDown("Jump") && !movement.grounded)
        {

        }
		
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
    }
}
