// --------------------CARO  GAME-----------------
//
//
// Copyright (c) Microsoft. All Rights Reserved.
// License under the Apache License, Version 2.0.
//
//
// Product by: Pham Hong Phuc
//
//
// ------------------------------------------------------

using System.Reflection;
using System.Resources;

namespace CaroGame.CaroManagement
{
    public class LanguageManager
    {
        private ResourceManager languageSwitch;

        public LanguageManager()
        {
            languageSwitch = new ResourceManager("CaroGame.Resources.locale.vi", Assembly.GetExecutingAssembly());
        }

        public string GetString(string key)
        {
            string value = languageSwitch.GetString(key);
            if (value != null) return value;
            return key;
        }
    }
}
