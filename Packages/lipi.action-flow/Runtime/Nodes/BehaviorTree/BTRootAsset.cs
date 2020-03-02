﻿using System;
using UnityEngine;

namespace ActionFlow
{
    [Serializable]
    [NodeInfo("BT/Root")]
    public class BTRoot : StatusNodeBase<NullStatus>, IBehaviorCompositeNode, INodeInput
    {

        public void OnInput(ref Context context)
        {
            OnTick(ref context);
        }

        // [NodeOutputBT(1)]
        // [HideInActionInspector]
        // public NullStatus[] Childs;

        public BehaviorStatus BehaviorInput(ref Context context)
        {
            throw new Exception("Root 暂时不支持做为行为树子节点");
        }


        public (bool, BehaviorStatus) Completed(ref Context context, int childIndex, BehaviorStatus result)
        {
            if (result == BehaviorStatus.Running)
            {
                context.Inactive(this);
            }
            else
            {
                context.Active(this);
            }
            return (false, BehaviorStatus.None);
        }

        [NodeOutputBT(1)]
        public override void OnTick(ref Context context)
        {
            var res = context.BTNodeOutput();
            if (res == BehaviorStatus.Running)
            {
                context.Inactive(this);
            }
            else
            {
                context.Active(this);
            }
        }
    }


    
    //public class BTRootAsset : NodeAsset<BTRoot>
    //{

    //}
}
