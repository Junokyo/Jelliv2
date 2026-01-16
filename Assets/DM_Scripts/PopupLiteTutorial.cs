
/*
 * Created on 2024
 *
 * Copyright (c) 2025 Dotmob Studio
 * Support : dotmobstudio@gmail.com
 */
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gley.Localization;

public class PopupLiteTutorial : Popup
{
	private List<string> tutorialDesc = new List<string>();

	private void Awake()
	{
		tutorialDesc.Add(API.GetText(WordIDs.PopupLiteTutorial_Des1));
		tutorialDesc.Add(API.GetText(WordIDs.PopupLiteTutorial_Des2));
		tutorialDesc.Add(API.GetText(WordIDs.PopupLiteTutorial_Des3));
		tutorialDesc.Add(API.GetText(WordIDs.PopupLiteTutorial_Des4));
		tutorialDesc.Add(API.GetText(WordIDs.PopupLiteTutorial_Des5));
		tutorialDesc.Add(API.GetText(WordIDs.PopupLiteTutorial_Des6));
		tutorialDesc.Add(API.GetText(WordIDs.PopupLiteTutorial_Des7));
		tutorialDesc.Add(API.GetText(WordIDs.PopupLiteTutorial_Des8));



	}



	private string[] tutorialTitle = new string[0];

	public GameObject[] ObjTutorailGroups;

	public Text TextTutorialTitle;

	public Text TextTutorialDesc;

	public void SetData(int tutorialIndex)
	{
		ObjTutorailGroups[tutorialIndex].SetActive(value: true);
		TextTutorialDesc.text = tutorialDesc[tutorialIndex];
	}

    
}
