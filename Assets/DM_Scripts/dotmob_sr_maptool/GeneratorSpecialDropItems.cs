/*
 * Created on 2024
 *
 * Copyright (c) 2025 Dotmob Studio
 * Support : dotmobstudio@gmail.com
 */
using UnityEngine;

namespace dotmob.sr.maptool
{
	public class GeneratorSpecialDropItems : MonoBehaviour
	{
		public void OnEndEdit(string text)
		{
			base.transform.parent.parent.GetComponent<GeneratorSpecialDropList>().OnChangeItemsProb(base.gameObject.name, text);
		}
	}
}
