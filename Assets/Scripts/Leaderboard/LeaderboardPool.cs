using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace LeaderboardSystem
{
    public class LeaderboardPool : Objectpooling<LeaderboardPool>
    {
        protected override void Awake()
        {
            poolObject = (GameObject)Resources.Load("LeaderboardElement");
            Initialize();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }
    }
}