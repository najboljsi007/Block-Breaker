using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField] Paddle paddle;
    Vector2 paddleToBallVector;

	// Use this for initialization
	void Start () {
        paddleToBallVector = transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
}
