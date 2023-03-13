using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interaction : MonoBehaviour
{
    public GameObject icon;
    public KeyCode interactionKeyCode = Constants.INTERACTION_KEY;
    private GameObject instantiatedIcon;
    private BoxCollider2D boxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();

        if (icon == null)
        {
            throw new System.Exception("Public Object empty on: " + gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (instantiatedIcon != null) {
            instantiatedIcon.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + (boxCollider2D.bounds.size.y / 2));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            instantiatedIcon = Instantiate(icon, gameObject.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(instantiatedIcon);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKey(interactionKeyCode))
        {
            interact(collision);
        }
    }

    public abstract void interact(Collider2D collision);
}

