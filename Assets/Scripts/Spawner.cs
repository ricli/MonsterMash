using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public Sprite[] fishSprites;
    public GameObject[] enemies;

    private void Awake()
    {
        fishSprites = Resources.LoadAll<Sprite>("fish");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
