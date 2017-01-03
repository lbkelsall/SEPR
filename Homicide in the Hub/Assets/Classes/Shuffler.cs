using UnityEngine;
using System.Collections.Generic;
using System.Linq;

	public class Shuffler
	{
		public Shuffler ()
		{
		}

		public void Shuffle<T>(T[] array){ //Based on Fisher-Yates Shuffle
			int n = array.Length;
			for (int i = 0; i < n; i++) {
				int r = i + (int)(Random.Range(0.0f,1.0f) * (n - i));
				T t = array[r];
				array[r] = array[i];
				array[i] = t;
			}
		}

	}


