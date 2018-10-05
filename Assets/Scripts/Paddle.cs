using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    // screenWidth is defined by camera size in world units
    [SerializeField] float screenWidthInUnits = 16f;
    // configuration parameters
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    // Use this for initialization
    void Start () {
		
	}
	
	void Update () {
        float mouseXPos = Input.mousePosition.x / Screen.width * screenWidthInUnits;

        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(mouseXPos, minX, maxX);
        transform.position = paddlePosition;
	}
}
