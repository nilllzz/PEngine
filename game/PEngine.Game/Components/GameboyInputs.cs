﻿using GameDevCommon.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using static Core;

namespace PEngine.Game.Components
{
    internal static class GameboyInputs
    {
        private static readonly InputDirectionType[] DIRECTION_INPUT_TYPES = new[] { InputDirectionType.ArrowKeys, InputDirectionType.WASD, InputDirectionType.LeftThumbStick, InputDirectionType.DPad };

        private static KeyboardHandler _kHandler;
        private static GamePadHandler _gHandler;
        private static ControlsHandler _cHandler;

        private static Keys _aKey, _bKey, _startKey, _selectKey;

        internal static void Initialize()
        {
            _kHandler = GetComponent<KeyboardHandler>();
            _gHandler = GetComponent<GamePadHandler>();
            _cHandler = GetComponent<ControlsHandler>();

            _aKey = Keys.Z;
            _bKey = Keys.X;
            _startKey = Keys.Enter;
            _selectKey = Keys.Space;
        }

        internal static bool APressed()
        {
            return Controller.IsActive &&
                (_kHandler.KeyPressed(_aKey) ||
                _gHandler.ButtonPressed(PlayerIndex.One, Buttons.A));
        }

        internal static bool ADown()
        {
            return Controller.IsActive &&
                (_kHandler.KeyDown(_aKey) ||
                _gHandler.ButtonDown(PlayerIndex.One, Buttons.A));
        }

        internal static bool BPressed()
        {
            return Controller.IsActive &&
                (_kHandler.KeyPressed(_bKey) ||
                _gHandler.ButtonPressed(PlayerIndex.One, Buttons.B));
        }

        internal static bool BDown()
        {
            return Controller.IsActive &&
                (_kHandler.KeyDown(_bKey) ||
                _gHandler.ButtonDown(PlayerIndex.One, Buttons.B));
        }

        internal static bool StartPressed()
        {
            return Controller.IsActive &&
                (_kHandler.KeyPressed(_startKey) ||
                _gHandler.ButtonPressed(PlayerIndex.One, Buttons.Start));
        }

        internal static bool SelectPressed()
        {
            return Controller.IsActive &&
                (_kHandler.KeyPressed(_selectKey) ||
                _gHandler.ButtonPressed(PlayerIndex.One, Buttons.Back));
        }

        internal static bool SelectDown()
        {
            return Controller.IsActive &&
                (_kHandler.KeyDown(_selectKey) ||
                _gHandler.ButtonDown(PlayerIndex.One, Buttons.Back));
        }

        internal static bool LeftDown()
        {
            return Controller.IsActive &&
                _cHandler.LeftDown(PlayerIndex.One, DIRECTION_INPUT_TYPES);
        }

        internal static bool RightDown()
        {
            return Controller.IsActive &&
                _cHandler.RightDown(PlayerIndex.One, DIRECTION_INPUT_TYPES);
        }

        internal static bool UpDown()
        {
            return Controller.IsActive &&
                _cHandler.UpDown(PlayerIndex.One, DIRECTION_INPUT_TYPES);
        }

        internal static bool DownDown()
        {
            return Controller.IsActive &&
                _cHandler.DownDown(PlayerIndex.One, DIRECTION_INPUT_TYPES);
        }

        internal static bool UpPressed()
        {
            return Controller.IsActive &&
                _cHandler.UpPressed(PlayerIndex.One, DIRECTION_INPUT_TYPES);
        }

        internal static bool DownPressed()
        {
            return Controller.IsActive &&
                _cHandler.DownPressed(PlayerIndex.One, DIRECTION_INPUT_TYPES);
        }

        internal static bool RightPressed()
        {
            return Controller.IsActive &&
                _cHandler.RightPressed(PlayerIndex.One, DIRECTION_INPUT_TYPES);
        }

        internal static bool LeftPressed()
        {
            return Controller.IsActive &&
                _cHandler.LeftPressed(PlayerIndex.One, DIRECTION_INPUT_TYPES);
        }
    }
}
