using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperController : MonoBehaviour
{
    [SerializeField]
    private List<Transform> positions = new List<Transform>();
    public int currentPosition = 0;
    float lastMoveTime;
    float moveDelay = 1.0f;

    //[HideInInspector]
    //public bool test;

    private void Start()
    {
        UpdatePosition();
        lastMoveTime = Time.time;

        StartCoroutine(Move());
    }

    //private void Update()
    //{
    //    if (Time.time > lastMoveTime + moveDelay)
    //    {
    //        MoveToNextPosition();
    //        lastMoveTime = Time.time;
    //    }
    //}

    IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveDelay);
            MoveToNextPosition();
        }
    }

    void MoveToNextPosition()
    {
        currentPosition++;

        if (currentPosition >= positions.Count)
        {
            //currentPosition = 0;
            //gameObject.SetActive(false);

            // Ta bort vår jumper och eventuellt ge poäng
            GameObject parent = transform.parent.gameObject;

            Destroy(parent);
        }
        else
        {
            UpdatePosition();
        }
    }

    void UpdatePosition()
    {
        transform.position = positions[currentPosition].position;
        //if (transform.position.y < -2.7)
        if (positions[currentPosition].gameObject.tag == "DangerPosition")
        {
            Debug.Log("Danger!!!");
        }

    }
}
