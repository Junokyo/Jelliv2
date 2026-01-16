using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gley.Localization;

public class PopupInGameItemStore : Popup
{
	public List<ItemsInGameStore> listItems = new List<ItemsInGameStore>();

	public ItemsInGameStore ObjBaseItem;

	public Text TextTitle;

	public Text TextDesc;

	public override void OnEnable()
	{
		base.OnEnable();
	}

	private void Caching()
	{
	}

	public void SetPopup(Booster.BoosterType boosterType, bool isTutorial = false)
	{
		Caching();
		if (!isTutorial)
		{
			MonoSingleton<UIManager>.Instance.SetCoinCurrencyMenuLayer(isPopupOverLayer: true);
		}
		switch (boosterType)
		{
		case Booster.BoosterType.Hammer:
			TextTitle.text = API.GetText(WordIDs.PopupInGameItemStore_titleHummer);
			TextDesc.text = API.GetText(WordIDs.PopupInGameItemStore_desHummer);
			break;
		case Booster.BoosterType.CandyPack:
			TextTitle.text = API.GetText(WordIDs.PopupInGameItemStore_titleBomb);
			TextDesc.text = API.GetText(WordIDs.PopupInGameItemStore_desBomb);
			break;
		case Booster.BoosterType.HBomb:
			TextTitle.text = API.GetText(WordIDs.PopupInGameItemStore_titleHRocket);
			TextDesc.text = API.GetText(WordIDs.PopupInGameItemStore_desHRocket);
			break;
		case Booster.BoosterType.VBomb:
			TextTitle.text = API.GetText(WordIDs.PopupInGameItemStore_titleVRocket);
			TextDesc.text = API.GetText(WordIDs.PopupInGameItemStore_desVRocket);
			break;
		}
		listItems.Clear();
		int boosterItemIndex = MonoSingleton<ServerDataTable>.Instance.GetBoosterItemIndex(boosterType);
		if (!MonoSingleton<PlayerDataManager>.Instance.dicBoosterItemList.ContainsKey(boosterItemIndex))
		{
			return;
		}
		for (int i = 0; i < MonoSingleton<PlayerDataManager>.Instance.dicBoosterItemList[boosterItemIndex].Count; i++)
		{
			if (MonoSingleton<ServerDataTable>.Instance.m_dicTableItemShop.ContainsKey(MonoSingleton<PlayerDataManager>.Instance.dicBoosterItemList[boosterItemIndex][i]))
			{
				GameObject gameObject;
				if (i > 0)
				{
					gameObject = Object.Instantiate(ObjBaseItem.gameObject);
					gameObject.transform.SetParent(ObjBaseItem.transform.parent, worldPositionStays: false);
				}
				else
				{
					gameObject = ObjBaseItem.gameObject;
				}
				gameObject.GetComponent<ItemsInGameStore>().SetItem(MonoSingleton<ServerDataTable>.Instance.m_dicTableItemShop[MonoSingleton<PlayerDataManager>.Instance.dicBoosterItemList[boosterItemIndex][i]], boosterType, i);
				listItems.Add(gameObject.GetComponent<ItemsInGameStore>());
			}
		}
	}

	public override void OnEventClose()
	{
		base.OnEventClose();
		MonoSingleton<UIManager>.Instance.HideCoinCurrentMenuLayer();
	}
}
