using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallCreation : MonoBehaviour
{
    public List<GameObject> balls = new List<GameObject>();
    void Start()
    {
        for (float i = -6.5f; i <= 6.5f; i = i + 1)
        {
            for (float j = -4f; j <= 4f; j = j + 1)
            {
                int k = Random.Range(0, 3);
                GameObject temp = Instantiate(balls[k], new Vector3(i, j, 0f), Quaternion.identity);
                temp.transform.parent = this.transform;
            }
        }
    }
    public void CreateBall(Vector3 position)
    {
        int k = Random.Range(0, 3);
        GameObject temp = Instantiate(balls[k], position, Quaternion.identity);
        temp.transform.parent = this.transform;
    }
    // Update is called once per frame
    void Update()
    {

    }

}
