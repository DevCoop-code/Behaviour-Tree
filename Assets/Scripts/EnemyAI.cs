using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://leekangw.github.io/posts/91/
public class EnemyAI : MonoBehaviour
{
    [Header("Range")] 
    [SerializeField] private float _detectRange = 10f;
    [SerializeField] private float _meleeAttackRange = 5f;

    [Header("Movement")] 
    [SerializeField] private float _movementSpeed = 10f;

    private Vector3 _originPos = default;
    private Transform _detectedPlayer = null;
    
    private BehaviourTreeRunner _BTRunner = null;


    private void Awake()
    {
        
    }

    INode SettingBT()
    {
        return new SelectorNode(new List<INode>()
        {
            new SequenceNode(new List<INode>()
            {
                new ActionNode()
            })
        })
    }

    // Attack Node
    INode.ENodeState CheckMeleeAttacking()
    {
        
    }
}
