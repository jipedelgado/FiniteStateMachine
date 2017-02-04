///<comment>
/// Déplacement dans une direction aléatoire d'amplitude step, toutes les "delay" secondes
/// dans un rayon de "rayonMaxi"
/// </comment>

using System.Collections;
using UnityEngine;

public class DrunkardController : MonoBehaviour {

    public float rayonMaxi = 10.0f;
    public float step = 0.3f;
    public float delay = 0.01f;
    private bool canMove;
    private bool asleep;
    public GameObject predator;

    public bool Asleep {
        get { return asleep; }
        set { asleep = value; }
    }
    void Start() {
        canMove = true;
        asleep = false;
        // calculé une seule fois
        rayonMaxi = rayonMaxi * rayonMaxi;
    }

    void Update() {
        if (canMove && !asleep) {
            Vector2 newDirection = step * Random.insideUnitCircle;
            Vector3 translation = new Vector3(newDirection.x, 0, newDirection.y);
            if ((transform.position + translation).magnitude < rayonMaxi) {
                transform.position += translation;
            }
            StartCoroutine(wait(delay));
        }
        if (this.tag == "Dead") {
            transform.position = predator.transform.position;
        }
    }

    private IEnumerator wait( float time ) {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }
}
