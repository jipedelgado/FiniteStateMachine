///<comment>
/// credit:
/// https://gamedevelopment.tutsplus.com/tutorials/finite-state-machines-theory-and-implementation--gamedev-11867
/// 
/// </comment>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour {

    public float moveSpeed = 5;

    private GameObject Home;
    private float DistanceDeCapture = 2.0f;
    private Stack<GameObject> panier;
    private GameObject target;
    private GameObject proie;
    private HomeController HomeScript;
    private DrunkardController DrunkardScript;

    private Transform myParent;

    void Start() {
        panier = new Stack<GameObject>();
        myParent = this.gameObject.transform.parent;
        Home = myParent.transform.GetChild(0).gameObject;
        HomeScript = Home.GetComponent<HomeController>();
        HomeScript.panier = new Stack<GameObject>();
        target = FindFarthest("Prey");
    }

    void Update() {
        if (Vector3.Distance(transform.position, target.transform.position) > DistanceDeCapture) {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        }
        if (panier.Count != 0) {
            panier.Peek().transform.position = transform.position;
        }
    }

    void OnCollisionEnter( Collision collision ) {
        GameObject go = collision.gameObject;

        if (go.tag == "Prey") {

            // on marque la proie comme morte
            go.tag = "Dead";

            // on collecte la proie
            this.panier.Push(go);

            // et on l'anesthesie
            DrunkardScript = go.GetComponent<DrunkardController>();
            DrunkardScript.Asleep = true;

            /// on se tourne vers Home
            target = Home;
            this.transform.LookAt(target.transform);
        }

        if (go == Home) {

            // on retire la proie du panier, qu'on vide
            proie = panier.Pop();

            // on dépose la proie dans le panier de Home
            if (HomeScript != null) {
                HomeScript.panier.Push(proie);
            }

            // on la stocke dans le garde-manger
            DrunkardScript.predator = Home;

            // stop ou encore?
            GameObject fartherTarget = FindFarthest("Prey");
            if (fartherTarget != null) {
                target = fartherTarget;
                this.transform.LookAt(target.transform);
            }
        }
    }

    ///<comment>
    /// credit:
    /// https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html 
    /// Find the closest GameObject tagged as tag
    /// </comment>
    GameObject FindClosest( string tag ) {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(tag);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos) {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance) {
                closest = go;
                distance = curDistance;
            }
        }
        //closest.tag = "Dead";
        return closest;
    }

    ///<comment>
    /// credit:
    /// https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html 
    /// Find the farthest GameObject tagged as tag
    /// </comment>
    GameObject FindFarthest( string tag ) {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(tag);
        if (gos.Length == 0) {
            return null;
        }
        GameObject Farthest = null;
        float distance = 0f;//Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos) {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance > distance) {
                Farthest = go;
                distance = curDistance;
            }
        }
        //Farthest.tag = "Dead";
        return Farthest;
    }
}

