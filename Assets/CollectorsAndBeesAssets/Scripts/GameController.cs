using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject collector;
    public float SizeOfUniverse = 20f;
    public GameObject proie;
    public int nombreProies;
    public float frequence = 2f;

    private bool canCreate;
    private int compteur;

    void Start() {
        compteur = 0;
        while (compteur < nombreProies) {
            create(proie, compteur++, "Prey");
        }
        create(collector, compteur, "Collector");
        canCreate = true;
    }

    void Update() {
        if (canCreate) {
            create(proie, compteur++, "Prey");
        }
    }

    private Vector3 randomVector() {
        float xInit = Random.Range(-SizeOfUniverse, SizeOfUniverse);
        float yInit = Random.Range(-SizeOfUniverse, SizeOfUniverse);
        float zInit = Random.Range(-SizeOfUniverse, SizeOfUniverse);
        return new Vector3(xInit, yInit, zInit);
    }

    private IEnumerator wait( float n ) {
        canCreate = false;
        yield return new WaitForSeconds(n);
        canCreate = true;
    }
    private void create( GameObject go, int numero, string tag ) {
        StartCoroutine(wait(frequence));
        GameObject newObject = Instantiate(go, randomVector(), Quaternion.identity) as GameObject;
        newObject.name = go.name + "#" + numero;
        newObject.tag = tag;
    }

}
