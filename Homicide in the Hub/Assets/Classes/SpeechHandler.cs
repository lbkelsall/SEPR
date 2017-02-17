using System.Collections.Generic;
using UnityEngine;

namespace Assets.Classes
{
    public class SpeechHandler
    {
        private static List<string> tempList = new List<string>();
        //access data (and print it)
        public static  List<string> accessData(JSONObject obj,string character)
        {
            tempList.Clear();
            foreach (var line in obj.GetField(character).list)
            {
                tempList.Add(line.str);
            }
            return tempList;
        }
    }
}



