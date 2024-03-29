﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour
{

    //GameObject firstLive;
    public float distance = 0.8f;
    private List<GameObject> lives = new List<GameObject>();

    //private void Start()
    //{
    //    InitializedLives(4);
    //}

    public void InitializedLives(int count)
    {
        // leta reda på firstLive
        GameObject firstLive = transform.GetChild(0).gameObject;
        lives.Add(firstLive);

        if (firstLive == null)
        {
            Debug.LogError("No lives");
            return;
        }

        // kopiera firstLive count gånger
        for (int i = 0; i < count - 1; i++)
        {
            GameObject live = Instantiate(firstLive);
            lives.Add(live);
            live.transform.parent = transform;
            Vector3 pos = live.transform.position;
            pos.x += distance * (i+1);
            live.transform.position = pos;
        }
    }

    public bool RemoveLifes()
    {

        if (lives.Count < 1)
        {
            return false;
        }

            GameObject lastLive = lives[lives.Count - 1];
            lives.RemoveAt(lives.Count - 1);

            Destroy(lastLive);
            return true;
        
    }
}
