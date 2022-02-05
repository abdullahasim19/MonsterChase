using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    private Vector3 tempPos;
    [SerializeField]
    private float minX, maxX;
    void Start()
    {
        GameObject temp= GameObject.FindWithTag("Player");
        if (temp == null)
            SceneManager.LoadScene("Main Menu");
        else
         player = temp.transform;   
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;

        tempPos = transform.position;
        tempPos.x = player.position.x;
        if (tempPos.x < minX)
            tempPos.x = minX;
        if (tempPos.x > maxX)
            tempPos.x = maxX;
        transform.position = tempPos;
    }
}
