
/*
 * Created on 2024
 *
 * Copyright (c) 2025 Dotmob Studio
 * Support : dotmobstudio@gmail.com
 */
public class MapDataDropBlock
{
	public int chipColor;

	public ChipType chipType = ChipType.SimpleChip;

	public MapDataDropBlock(ChipType chipType, int chipColor)
	{
		this.chipType = chipType;
		this.chipColor = chipColor;
	}

	public MapDataDropBlock(string strJson)
	{
	}
}
