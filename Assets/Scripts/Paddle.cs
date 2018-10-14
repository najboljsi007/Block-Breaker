using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    // screenWidth is defined by camera size in world units
    [SerializeField] float screenWidthInUnits = 16f;
    
    // configuration parameters
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    // cache references
    GameSession gameSession;
    Ball ball;

    void Start () {
		gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }
	
	void Update () {
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePosition;
	}

    private float GetXPos()
    {
        if (gameSession.IsAutoplayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
