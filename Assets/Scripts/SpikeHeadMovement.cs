using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHeadMovement : MonoBehaviour
{
    public float maxDistance = 1f;
    public float movement = 0.002f;

    private Vector2 startPosition;
    private float finalPositionY;
    private enum State {goingDown, goingUp};
    private State state;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        //Debug.Log("startPosition.y:" + startPosition.y);
        finalPositionY = startPosition.y - maxDistance;
        state = State.goingDown;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = transform.position;
        UpdateState(currentPosition);
        UpdateMovement(currentPosition);
        //Debug.Log(state);
        //Debug.Log(transform.position);
    }

    private void UpdateState(Vector2 currentPosition) {
        //Debug.Log("currentPosition.y:" + currentPosition.y + "   finalPositionY:"+ finalPositionY);
        if (state == State.goingDown && currentPosition.y <= finalPositionY) state = State.goingUp;
        else if (state == State.goingUp && currentPosition.y >= startPosition.y) state = State.goingDown;
    }

    private void UpdateMovement(Vector2 currentPosition) {        
        if (state == State.goingDown) transform.position = new Vector2(currentPosition.x, (currentPosition.y - movement));
        else if (state == State.goingUp) transform.position = new Vector2(currentPosition.x, (currentPosition.y + movement));
    }

}
