///<comment>
/// credit:
/// https://gamedevelopment.tutsplus.com/tutorials/finite-state-machines-theory-and-implementation--gamedev-11867
/// </comment>

using UnityEngine;

public class AntController : MonoBehaviour {

    public GameObject home;
    public GameObject leaf;
    public float DistanceDeSecurité = 2.0f;
    public float moveSpeed =5;
    public float turnSpeed = 0.2f;
    public float delay = 5f;

    private FSM brain;

    void Start() {
        brain = new FSM();
        brain.ActualState = FSM.State.findLeaf;
    }

    void Update() {
        switch (brain.ActualState) {
            case FSM.State.findLeaf: {
                    goTo(leaf, FSM.State.goHome);
                }
                break;
            case FSM.State.goHome: {
                    goTo(home, FSM.State.findLeaf);
                }
                break;
            default:
                break;
        }
    }

    void goTo( GameObject target , FSM.State next) {
        {
            transform.LookAt(target.transform);
            if (Vector3.Distance(transform.position, target.transform.position) > 0.5f) {
                transform.localPosition = Vector3.Lerp(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            }
            else {
                brain.ActualState = next;
            }
        }
    }
}
