using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 자식 노드를 왼쪽에서 오른쪽으로 진행하면서 Failure 상태가 나올때까지 진행
 * Evaluate Method 구현
 * - 자식 상태 Running 일 때 -> Running 반환
 * - 자식 상태 Success 일 때 -> 다음 자식으로 이동
 * - 자식 상태 Failure 일 때 -> Failure 반환
 *
 * Running 상태일시 그 상태를 계속 유지해야 하기 때문에 다음 자식 노드로 이동하면 안되고
 * 다음 프레임 때도 그 자식에 대한 평가를 진행해야만 함 
 */
public sealed class SequenceNode : INode
{
    private IList<INode> _childs;

    public SequenceNode(List<INode> childs)
    {
        _childs = childs;
    }

    public INode.ENodeState Evaluate()
    {
        if (_childs == null || _childs.Count == 0) { return INode.ENodeState.FAILURE; }

        foreach (INode child in _childs)
        {
            INode.ENodeState currentNodeState = child.Evaluate();

            if (currentNodeState == INode.ENodeState.RUNNING || currentNodeState == INode.ENodeState.FAILURE) { return currentNodeState; }
            if (currentNodeState == INode.ENodeState.SUCCESS) { continue; }
        }

        return INode.ENodeState.SUCCESS;
    }
}
