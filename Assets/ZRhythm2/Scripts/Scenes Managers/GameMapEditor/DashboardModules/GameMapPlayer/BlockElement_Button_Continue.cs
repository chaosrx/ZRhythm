﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurningxEmpires.ZRhythm.Editor{
	/// <summary>
	/// 從目前編輯的音符位置播放譜麵
	/// </summary>
	public class BlockElement_Button_Continue : BlockElement_Button {
		private static GameMapPlayerModuleManager manager{get{return GameMapPlayerModuleManager.getInstace;}}

		public override void onClick () {
			manager.Continue ();
		}
	}
}