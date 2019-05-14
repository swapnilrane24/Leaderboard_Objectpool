using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace LeaderboardSystem
{
    public class LeaderboardElement : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI rankTxt, nameTxt, scoreTxt;

        public void SetLeaderboardDetails(string rankVal, string nameVal, string scoreVal)
        {
            rankTxt.text = rankVal;
            nameTxt.text = nameVal;
            scoreTxt.text = scoreVal;    
        }

    }
}