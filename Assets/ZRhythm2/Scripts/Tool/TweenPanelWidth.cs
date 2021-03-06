﻿using UnityEngine;
using System.Collections;

public class TweenPanelWidth : UITweener
{
	public int from = 100;
	public int to = 100;
	public bool updateTable = false;

	UIPanel mPanel;
	UITable mTable;

	public UIPanel cachedPanel { get { if (mPanel == null) mPanel = GetComponent<UIPanel>(); return mPanel; } }

	[System.Obsolete("Use 'value' instead")]
	public float width { get { return this.value; } set { this.value = value; } }

	/// <summary>
	/// Tween's current value.
	/// </summary>

	public float value { get { return cachedPanel.width; } set { 
			cachedPanel.baseClipRegion = new Vector4(
				cachedPanel.baseClipRegion.x,
				cachedPanel.baseClipRegion.y,
				value,
				cachedPanel.baseClipRegion.w
			);
		} }

	/// <summary>
	/// Tween the value.
	/// </summary>

	protected override void OnUpdate (float factor, bool isFinished)
	{
		value = Mathf.RoundToInt(from * (1f - factor) + to * factor);

		if (updateTable)
		{
			if (mTable == null)
			{
				mTable = NGUITools.FindInParents<UITable>(gameObject);
				if (mTable == null) { updateTable = false; return; }
			}
			mTable.repositionNow = true;
		}
	}

	/// <summary>
	/// Start the tweening operation.
	/// </summary>

	static public TweenPanelWidth Begin (UIPanel panel, float duration, float width)
	{
		TweenPanelWidth comp = UITweener.Begin<TweenPanelWidth>(panel.gameObject, duration);
		comp.from = (int)panel.width;
		comp.to = (int)width;

		if (duration <= 0f)
		{
			comp.Sample(1f, true);
			comp.enabled = false;
		}
		return comp;
	}

	[ContextMenu("Set 'From' to current value")]
	public override void SetStartToCurrentValue () { from = (int)value; }

	[ContextMenu("Set 'To' to current value")]
	public override void SetEndToCurrentValue () { to = (int)value; }

	[ContextMenu("Assume value of 'From'")]
	void SetCurrentValueToStart () { value = from; }

	[ContextMenu("Assume value of 'To'")]
	void SetCurrentValueToEnd () { value = to; }
}

