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

using CaroGame.Configuration;
using System.Reflection;
using System.Resources;

namespace CaroGame.CaroManagement
{
    public class LanguageManager
    {
        private ResourceManager viLanguage, enLanguage;

        public LanguageManager()
        {
            viLanguage = new ResourceManager("CaroGame.Resources.locale.vi", Assembly.GetExecutingAssembly());
            enLanguage = new ResourceManager("CaroGame.Resources.locale.en", Assembly.GetExecutingAssembly());
        }

        public string GetString(string key)
        {
            ResourceManager re = null;
            if (SettingConfig.Language.Equals(Constants.VI_LANGUAGE)) re = viLanguage;
            else re = enLanguage;
            string value = re.GetString(key);
            if (value != null) return value;
            return key;
        }
    }
}
