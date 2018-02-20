using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    public Camera camera;
    public GameObject player;
    public float rBound;
    public float lBound;
    public float tBound;
    public float bBound;

    private Vector3 offset;
    private SpriteRenderer spriteR;

    void Start()
    {
        offset = transform.position - player.transform.position;
        spriteR = GameObject.FindWithTag("Background").GetComponent<SpriteRenderer>();

    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
