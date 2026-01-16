
/*
 * Created on 2024
 *
 * Copyright (c) 2025 Dotmob Studio
 * Support : dotmobstudio@gmail.com
 */
public class MapDataDropProbBlock : MapDataDropBlock
{
	public int prob;

	public MapDataDropProbBlock(ChipType chipType, int chipColor, int prob)
		: base(chipType, chipColor)
	{
		this.prob = prob;
	}
}
