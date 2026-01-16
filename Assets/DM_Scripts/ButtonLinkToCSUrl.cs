/*
 * Created on 2024
 *
 * Copyright (c) 2025 Dotmob Studio
 * Support : dotmobstudio@gmail.com
 */

using UnityEngine;

public class ButtonLinkToCSUrl : MonoBehaviour
{
	private void Start()
	{
	}

	public void OnPressButton()
	{
		Application.OpenURL(MonoSingleton<ServerDataTable>.Instance.faqCsUrl);
	}
}
