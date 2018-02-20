using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {
    public float size = .1f;
    BoxCollider2D collider;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    void Update () {
        Vector3 scale = new Vector3(size, size, 0);
        transform.localScale = scale;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (size >= collision.GetComponentInParent<Interaction>().size)
        {
            size += .01f;
            if (size >= .15 && gameObject.CompareTag("Player"))
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("PlayerSprites/Fish3+");
            }
            if (size >= .2 && gameObject.CompareTag("Player"))
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("PlayerSprites/Fish3++");
            }
        } else
        {
            if(gameObject.CompareTag("Player"))
            {
                Application.Quit();
            }
            Destroy(gameObject);
        }
    }
}
