///<comment>
/// credit:
/// https://gamedevelopment.tutsplus.com/tutorials/finite-state-machines-theory-and-implementation--gamedev-11867
/// </comment>

using UnityEngine;

public class StackAntController : MonoBehaviour {

    public GameObject home;
    public GameObject leaf;
    public float DistanceDeSecurité = 2.0f;
    public float moveSpeed = 5;
    public float turnSpeed = 0.2f;

    private StackFSM brain;

    void Start() {
        brain = new StackFSM();
        brain.pushState(StackFSM.State.findLeaf);
    }

    void Update() {
        switch (brain.getCurrentState()) {
            case StackFSM.State.findLeaf: {
                    goTo(leaf, StackFSM.State.goHome);
                }
                break;
            case StackFSM.State.goHome: {
                    goTo(home, StackFSM.State.findLeaf);
                }
                break;
            default:
                break;
        }
    }

    void goTo( GameObject target, StackFSM.State next ) {
        {
            transform.LookAt(target.transform);
            if (Vector3.Distance(transform.position, target.transform.position) > 0.5f) {
                transform.localPosition = Vector3.Lerp(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            }
            else {
                brain.popState();
                brain.pushState(next);
            }
        }
    }
}
