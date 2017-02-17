
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Classes
{

    public class SpeechHandler
    {

        Dictionary<string,List<string>> tempDict = new Dictionary<string, List<string>>();
        List<string> tempList = new List<string>();
        private string key;

        //access data (and print it)
        public Dictionary<string, List<string>> accessData(JSONObject obj)
        {
            switch (obj.type)
            {
                case JSONObject.Type.OBJECT:
                    for (int i = 0; i < obj.list.Count; i++)
                    {
                        key = obj.keys[i];
                        JSONObject j = obj.list[i];
                        //Debug.Log("Current key is: " + key)
                        tempList.Clear();
                        accessData(j);
                        Debug.Log("Adding List to Key: " + key + " | List Length is: " + tempList.Count);
                        foreach (var line in tempList)
                        {
                            //Debug.Log(line);
                        }
                        tempDict.Add(key, tempList);
                    }
                    break;

                case JSONObject.Type.ARRAY:
                    foreach (JSONObject j in obj.list)
                    {
                        accessData(j);
                    }

                    break;
                case JSONObject.Type.STRING:
                    //Debug.Log("Adding line to list: " + obj.str);
                    tempList.Add(obj.str);
                    break;
            }
            return tempDict;
        }
    }
}



