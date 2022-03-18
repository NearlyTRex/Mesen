﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Mesen.Utilities.GlobalMouseLib
{
	public static class GlobalMouse
	{
		private static IGlobalMouseImpl _impl;

		static GlobalMouse()
		{
			if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
				_impl = new GlobalMouseWindowsImpl();
			} else {
				_impl = new GlobalMouseStubImpl();
			}
		}

		public static bool IsMouseButtonPressed(MouseButtons button)
		{
			return _impl.IsMouseButtonPressed(button);
		}

		public static MousePosition GetMousePosition()
		{
			return _impl.GetMousePosition();
		}

		public static void SetMousePosition(uint x, uint y)
		{
			_impl.SetMousePosition(x, y);
		}

		public static void SetCursorIcon(CursorIcon icon)
		{
			_impl.SetCursorIcon(icon);
		}

		public static void CaptureCursor(int x, int y, int width, int height)
		{
			_impl.CaptureCursor(x, y, width, height);
		}

		public static void ReleaseCursor()
		{
			_impl.ReleaseCursor();
		}
	}

	public enum MouseButtons
	{
		Left = 1,
		Right = 2,
		Middle = 3
	}

	public enum CursorIcon
	{
		Hidden,
		Arrow,
		Cross
	}

	public struct MousePosition
	{
		public int X;
		public int Y;

		public MousePosition(int x, int y)
		{
			X = x;
			Y = y;
		}
	}
}