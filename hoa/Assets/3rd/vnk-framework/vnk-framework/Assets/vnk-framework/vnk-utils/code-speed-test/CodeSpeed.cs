using System.Diagnostics;
using UnityEngine;

namespace Yoolax.Framework
{
    public class CodeSpeed 
    {
        private static Stopwatch stopwatch = new Stopwatch();
        public static void StartCode()
        {
            stopwatch.Reset();
            stopwatch.Start();
        }
        public static void EndCode()
        {
            stopwatch.Stop();
          //  Debug.Log
          // Debug.LogError(stopwatch.ElapsedTicks);
        }
        public static void EndCodeToMilisecond()
        {
            stopwatch.Stop();
           // Debug.LogError(stopwatch.ElapsedMilliseconds);
        }
    }
}
