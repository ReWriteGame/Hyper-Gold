using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class GameRule : MonoBehaviour
{
   [SerializeField] private Cube cube;
   [SerializeField] private Text textBit;
   [SerializeField] private ScoreCounter scoreCounter;


   public UnityEvent playerLoseNumberEvent;
   public UnityEvent playerWinNumberEvent;

   public float CountScore()
   {
      float score = 0;
      if (!String.IsNullOrEmpty(textBit.text))
         score = float.Parse(textBit.text);

      if (score > scoreCounter.Score)
         score = scoreCounter.Score;
      
      return score;
   }

   
   public void CompareResult()
   {
      if (cube.CurrentSideAbove.Number > 3)
      {
         scoreCounter.Add(CountScore());
         playerWinNumberEvent?.Invoke();
      }
      else
      {
         scoreCounter.TakeAway(CountScore());
         playerLoseNumberEvent?.Invoke();
      }
   }
}
