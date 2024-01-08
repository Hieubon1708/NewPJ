using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonHandler : MonoBehaviour
{
    public static GameObject player;
    private GameObject[] listBackground;

    public static Animator animatorPlayer;

    public static Rigidbody2D rigidbodyPlayer;

    private static Collider2D[] listBackgroundCollider2D;
    private static Collider2D playerCollider2D;

    public static int numberOfJump;

    void Awake()
    {
        player = GameObject.Find("Player");
        
        animatorPlayer = player.GetComponent<Animator>();
        rigidbodyPlayer = player.GetComponent<Rigidbody2D>();
        playerCollider2D = player.GetComponent<Collider2D>();

        //tìm các khối đất theo tag 
        listBackground = GameObject.FindGameObjectsWithTag("Background");
        
        listBackgroundCollider2D = new Collider2D[listBackground.Length];
        for (int i = 0; i < listBackground.Length; i++)
        {
            listBackgroundCollider2D[i] = listBackground[i].GetComponent<Collider2D>();
        }
    }

    public static bool CheckCollision()
    {
        foreach (var col in listBackgroundCollider2D)
        {
            if (playerCollider2D.IsTouching(col))
            {
                numberOfJump = 0;
                return false;

            }
        }
        return true;
    }
}
