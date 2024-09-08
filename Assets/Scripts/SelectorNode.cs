using System.Collections.Generic;

/*
 * 자식 노드 중에 처음으로 Success나 Running 상태를 가진 노드가 발생시 그 노드까지 진행하고 멈춤
 * Evaluate Method 구현
 * - 자식 상태가 Running 일시 -> Running 반환
 * - 자식 상태가 Success 일시 -> Success 반환
 * - 자식 상태가 Failure 일시 -> 다음 자식으로 이동  
 */
public sealed class SelectorNode : INode
{
    private List<INode> _childs;

    public SelectorNode(List<INode> childs)
    {
        _childs = childs;
    }

    public INode.ENodeState Evaluate()
    {
        if (_childs == null) { return INode.ENodeState.FAILURE; }

        foreach (INode child in _childs)
        {
            INode.ENodeState currentNodeState = child.Evaluate();
            if (currentNodeState != INode.ENodeState.FAILURE) { return currentNodeState; }
        }

        return INode.ENodeState.FAILURE;
    }
}
