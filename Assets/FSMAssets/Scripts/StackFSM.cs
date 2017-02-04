///<comment>
/// Definit la liste des états et la pile des etat
/// 
/// </comment>

using System.Collections.Generic;

public class StackFSM  {
    public enum State { findLeaf, goHome, runAway };
    private Stack<State>  stack;

    public StackFSM() {
        stack = new Stack<State>();
    }
        
    public void pushState(State s ) {
        stack.Push(s);
    }

    public State popState() {
        return stack.Pop();
    }

    public State getCurrentState() {
        return stack.Peek();
    }
}
