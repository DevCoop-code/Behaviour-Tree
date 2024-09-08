using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INode
{
    public enum ENodeState
    {
        RUNNING,
        SUCCESS,
        FAILURE
    }

    public ENodeState Evaluate();
}
