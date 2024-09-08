using System;

/*
 * 실제로 어떤 행위를 하는 노드
 * Func() 델리게이트를 통해 행위를 전달받아 실행 
 */
public sealed class ActionNode : INode
{
    private Func<INode.ENodeState> _onUpdate = null;

    public ActionNode(Func<INode.ENodeState> onUpdate)
    {
        _onUpdate = onUpdate;
    }

    public INode.ENodeState Evaluate()
    {
        return _onUpdate?.Invoke() ?? INode.ENodeState.FAILURE;
    }
}
