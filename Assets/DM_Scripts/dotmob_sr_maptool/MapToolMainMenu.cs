/*
 * Created on 2024
 *
 * Copyright (c) 2025 Dotmob Studio
 * Support : dotmobstudio@gmail.com
 */
using UnityEngine;
using UnityEngine.UI;

namespace dotmob.sr.maptool
{
	public class MapToolMainMenu : MonoBehaviour
	{
		public enum MenuType
		{
			Drop,
			Slot,
			Direction,
			Block,
			Obstacle,
			Mode,
			Collect
		}

		public MenuType CurrentMenuType;

		public Toggle firstOnTabMenu;

		private void Awake()
		{
			MapToolSelectObject[] componentsInChildren = GetComponentsInChildren<MapToolSelectObject>();
			foreach (MapToolSelectObject mapToolSelectObject in componentsInChildren)
			{
				mapToolSelectObject.gameObject.SetActive(value: false);
			}
		}

		private void Start()
		{
			firstOnTabMenu.isOn = true;
		}
	}
}
