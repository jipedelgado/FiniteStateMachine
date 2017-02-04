using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM {

    public enum State { findLeaf, goHome, runAway };
    private State actualState;

    public State ActualState {
        get { return actualState; }
        set { actualState = value; }
    }
    public FSM() {

    }
}
