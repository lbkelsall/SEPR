using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;
using UnityEditor;
using UnityEngine;
using SimpleJson;
using Object = System.Object;

namespace Assets.Classes
{

    //Abstract generic JSON handler to be inherited by any child handlers
    public abstract class JSONHandler<T>
    {
        //path to JSON File
        private static string PATH = "insertpathhere";
        private JSONObject obj;
        private Dictionary<string, T> map;
        private T result;
        protected JSONHandler(string name)
        {
            try
            {
                obj = new JSONObject(File.ReadAllText(PATH));
                map = new Dictionary<string, T>();
                foreach (var j in obj.list)
                {
                    Debug.Log(j.GetField("name"));
                    map.Add(j.GetField("name").str, load(j));
                }
            }
            catch (IOException e)
            {
                Debug.Log(e.StackTrace);
            }
        }

        protected abstract T load(JSONObject j);

        public T get(string key)
        {
            if(!map.TryGetValue(key, out result))
        {
        }
            return result;
        }
    }


}