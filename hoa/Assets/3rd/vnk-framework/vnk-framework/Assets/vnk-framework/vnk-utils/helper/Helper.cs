using DG.Tweening;
using DG.Tweening.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace Yoolax.Framework
{
    public static class Helper
    {
        public static int RandomSystem(List<float[]> lstRate)
        {
            //Get %
            for (int i = 1; i < lstRate.Count; i++)
            {
                lstRate[i][1] = lstRate[i - 1][1] + lstRate[i][1];
            }
            float maxRate = lstRate[lstRate.Count - 1][1];
            float rate = UnityEngine.Random.Range(0, maxRate);
            int number;
            float newRate;
            for (int i = 0; i < lstRate.Count; i++)
            {
                newRate = lstRate[i][1];
                if (rate < newRate)
                {
                    number = (int)lstRate[i][0];
                    return number;
                }
            }
            number = (int)lstRate[0][0];
            return number;
        }
        public static string FormatTimer(int secs)
        {
            int hours = secs / 3600;
            int minutes = (secs - hours * 3600) / 60;
            int seconds = secs - hours * 3600 - minutes * 60;

            if (hours == 0)
            {
                return $"{minutes:00}:{seconds:00}";
            }

            return $"{hours:00}:{minutes:00}:{seconds:00}";
        }
        public static string FormatTimerChar(int secs)
        {
            int hours = secs / 3600;
            int minutes = (secs - hours * 3600) / 60;
            int seconds = secs - hours * 3600 - minutes * 60;

            if (hours == 0)
            {
                return $"{minutes:00}m{seconds:00}s";
            }

            return $"{hours:00}h{minutes:00}m{seconds:00}s";
        }
        public static string FormatTimerChar_ToMinutes(int secs)
        {
            int hours = secs / 3600;
            int minutes = (secs - hours * 3600) / 60;

            if (hours == 0)
            {
                return $"{minutes:00}m";
            }

            return $"{hours:00}h{minutes:00}m";
        }
        public static string FormatCurrency(int number)
        {
            int value; 
            value = number / 1000000;
            if (value > 0)
            {
                int val = number % 1000000;
                return $"{value}.{val / 100000}M";
            }

            value = number / 1000;
            if (value > 0)
            {
                int val = number % 1000;
                return $"{value}.{val / 100}K";
            }

            return number.ToString();
        }

        public static bool RandomResult_100Percent(int rate)
        {
            int rd = UnityEngine.Random.Range(0, 100);
            if (rd <= rate)
            {
                return true;
            }
            return false;
        }
        public static bool RandomResult_1000(int rate)
        {
            int rd = UnityEngine.Random.Range(0, 1000);
            if (rd <= rate)
            {
                return true;
            }
            return false;
        }

        //Shuffle
        private static System.Random rng = new System.Random();
        public static void Shuffle<T>(this IList<T> list)
        {

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        //IEmurator
        private static Dictionary<float, WaitForSeconds> dicWait = new Dictionary<float, WaitForSeconds>();
        public static WaitForSeconds Wait(float time)
        {
            WaitForSeconds waitForSeconds = null;
            dicWait.TryGetValue(time, out waitForSeconds);
            if (waitForSeconds == null)
            {
                waitForSeconds = new WaitForSeconds(time);
                dicWait.Add(time, waitForSeconds);
            }
            return waitForSeconds;
        }

        //IEmuratorRealtime
        private static Dictionary<float, WaitForSecondsRealtime> dicWaitRealTime = new Dictionary<float, WaitForSecondsRealtime>();
        public static WaitForSecondsRealtime WaitRealTime(float time)
        {
            WaitForSecondsRealtime waitForSecondsRealtime = null;
            dicWaitRealTime.TryGetValue(time, out waitForSecondsRealtime);
            if (waitForSecondsRealtime == null)
            {
                waitForSecondsRealtime = new WaitForSecondsRealtime(time);
                dicWaitRealTime.Add(time, waitForSecondsRealtime);
            }
            return waitForSecondsRealtime;
        }

        public static Vector2 GetRandomPos(float innerRadius, float outerRadius)
        {
            return UnityEngine.Random.insideUnitCircle.normalized * UnityEngine.Random.Range(innerRadius, outerRadius);
        }
        public static Vector3 GetRandomPos3D(float innerRadius, float outerRadius)
        {
            return UnityEngine.Random.insideUnitSphere.normalized * UnityEngine.Random.Range(innerRadius, outerRadius);
        }
        public static string RemoveSpecialCharacter(string myString)
        {
            var newChars = myString.Select(ch =>
                                 ((ch >= 'a' && ch <= 'z')
                                      || (ch >= 'A' && ch <= 'Z')
                                      || (ch >= '0' && ch <= '9')
                                      || ch == '-') ? ch : '-')
                           .ToArray();

            return new string(newChars);
        }

        public static Tweener DoText(this TextMeshProUGUI label, string context, float speed = 0.02f, bool ignoreTimeScale = true)
        {
            if (label == null || string.IsNullOrEmpty(context))
            {
                return null;
            }
            float duration = context.Length * speed;
            label.text = "";
            int index = 0;
            DOGetter<int> getter = () => { return index; };
            DOSetter<int> setter = (x) => {
                index = x;
                label.text = context.Substring(0, x);
                //AudioManager.Instance.PlayAudio_CharChanged();
                // Debug.LogError("123");
            };
            return DOTween.To(getter, setter, context.Length, duration).SetUpdate(ignoreTimeScale);
        }

        public static int GetSecondFromTime(DateTime preTime, DateTime curTime)
        {
            TimeSpan timeSpan = curTime - preTime;
            return (timeSpan.Days * 86400) + (timeSpan.Hours * 3600) + (timeSpan.Minutes * 60) + timeSpan.Seconds;
        }
        public static int GetSecondFromTimeSpan(TimeSpan timeSpan)
        {
            return (timeSpan.Days * 86400) + (timeSpan.Hours * 3600) + (timeSpan.Minutes * 60) + timeSpan.Seconds;
        }
        public static TimeSpan GetTimeSpanFromSecond(int second)
        {
            int day = second / 86400;
            second = second % 86400;

            int hour = second / 3600;
            second = second % 3600;

            int minute = second / 60;
            second = second % 60;

            return new TimeSpan(day, hour, minute, second);
        }
        public static DateTime EndOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }

        //Get day calendar
        public static int GetStartDayInWeek(int currentDay, int currentDayInWeek)
        {
            int maxDayInWeek = 6;
            for (int day = currentDay; day > 1; day--)
            {
                currentDayInWeek--;
                if (currentDayInWeek < 0)
                {
                    currentDayInWeek = maxDayInWeek;
                }
            }
            return currentDayInWeek;
        }

        //Rotate
        public static Quaternion GetQuaternionFromDirection(Vector3 positionA, Vector3 positionB)
        {
            Quaternion rotation = Quaternion.LookRotation(positionB - positionA);
            return rotation;
        }

        // Get Time
        public static int GetTheRestOfTheDay(DateTime curTime)
        {
            return 86400 - ((curTime.Hour * 3600) + (curTime.Minute * 60) + curTime.Second);
        }

        //Load Texture from Web

        public static async Task<Texture2D> LoadTextureFromWeb(string url)
        {
            using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
            {
                // begin request:
                var asyncOp = www.SendWebRequest();

                // await until it's done: 
                while (asyncOp.isDone == false)
                    await Task.Delay(1000 / 30);//30 hertz

                // read results:
                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log($"{www.error}, URL:{www.url}");
                    return null;
                }
                else
                {
                    // return valid results:
                    return DownloadHandlerTexture.GetContent(www);
                }
            }
        }

        //GetTextureRead
        public static Texture2D GetTextureReadable(Texture2D source)
        {
            RenderTexture renderTex = RenderTexture.GetTemporary(
                        source.width,
                        source.height,
                        0,
                        RenderTextureFormat.Default,
                        RenderTextureReadWrite.Linear);

            Graphics.Blit(source, renderTex);
            RenderTexture previous = RenderTexture.active;
            RenderTexture.active = renderTex;
            Texture2D readableText = new Texture2D(source.width, source.height);
            readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
            readableText.Apply();
            RenderTexture.active = previous;
            RenderTexture.ReleaseTemporary(renderTex);
            return readableText;
        }


        //GetLinkedList
        static LinkedList<int> stack = new LinkedList<int>();
        //public static LinkedList<int> SplitNumber(int number)
        //{
        //    stack.Clear();
        //    while (number > 0)
        //    {
        //        stack.AddFirst(number % 10);
        //        number = number / 10;
        //    }

        //    return stack;
        //}
        public static LinkedList<int> SplitNumber2(int number)
        {
            stack.Clear();
            while (number > 0)
            {
                stack.AddFirst(number % 100);
                number = number / 100;
            }

            return stack;
        }
        public static void GemDetail(int gem, out int type, out int status, out int right, out int bottom)
        {
            type = gem / 1000;
            var temp = gem % 1000;
            status = temp / 100;
            var tempp = temp % 100;
            right = tempp / 10;
            bottom = tempp % 10;
        }

        //Clear Log
        public static void ClearLog()
        {
#if UNITY_EDITOR
            var assembly = System.Reflection.Assembly.GetAssembly(typeof(UnityEditor.Editor));
            var type = assembly.GetType("UnityEditor.LogEntries");
            var method = type.GetMethod("Clear");
            method.Invoke(new object(), null);
#endif
        }

        //Get all transform
        public static List<Transform> GetAllTransforms(Transform parent)
        {
            var transformList = new List<Transform>();
            BuildTransformList(transformList, parent);
            return transformList;
        }

        private static void BuildTransformList(ICollection<Transform> transforms, Transform parent)
        {
            if (parent == null) { return; }
            foreach (Transform t in parent)
            {
                transforms.Add(t);
                BuildTransformList(transforms, t);
            }
        }

        public static Texture2D ToTexture2D(Texture texture)
        {
            Texture2D dest = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);

           // Graphics.CopyTexture(renderTexture, dest);

            return dest;
        }
    }
}
