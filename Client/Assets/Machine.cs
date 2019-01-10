using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Machine : MonoBehaviour
{

    public GameObject ball;
    private float deltaTime = 0;
    public float createBallAfter = 1;
    public GameObject handle;
    public Screen screen;
    public int balls = 1000;

    public Text text;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        deltaTime = deltaTime + Time.deltaTime;
        if (deltaTime > createBallAfter)
        {
            float angle = handle.transform.transform.eulerAngles.x;

            if (angle > 0)
            {

                Vector3 nextPosition = new Vector3(-0.53f, 22.81f, 8.03f);
                Vector3 spawnPosition = new Vector3(-0.53f, 20.24f, 6.27f);
                Vector3 power = nextPosition - spawnPosition;
                GameObject newBall = Instantiate(ball);
                newBall.transform.position = spawnPosition;

                Vector3 pow = power * (703 - (angle / 10));
                ((Rigidbody)newBall.GetComponent("Rigidbody")).AddForce(pow);

                this.balls = this.balls - 1;

                text.text = "Balls: " + this.balls;
            }

            //Debug.Log(handle.transform.transform.eulerAngles);
            deltaTime = deltaTime - createBallAfter;
        }

    }

    public void onEvent(string eventName, string data)
    {
        if (eventName == "Collision" && data == "winHole")
        {
            this.screen.Spin(Random.RandomRange(1,9), Random.RandomRange(1, 9), Random.RandomRange(1, 9));
        }
    }

}