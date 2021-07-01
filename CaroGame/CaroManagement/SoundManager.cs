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

using WMPLib;

namespace CaroGame.CaroManagement
{
    public class SoundManager
    {
        private WindowsMediaPlayer sound;
        public SoundManager()
        {
            sound = new WindowsMediaPlayer();
        }

        public bool IsLoop
        {
            get
            {
                return sound.settings.getMode("loop");
            }
            set
            {
                sound.settings.setMode("loop", value);
            }
        }

        public int Volume
        {
            get
            {
                return sound.settings.volume;
            }
            set
            {
                sound.settings.volume = value;
            }
        }

        public void Play(string nameMusic)
        {
            //sound.URL = string.Format("../../Resources/Sounds/{0}", nameMusic);
            sound.controls.play();
        }

        public void Stop()
        {
            sound.controls.stop();
        }

        public void Pause()
        {
            sound.controls.pause();
        }

        public void Resume()
        {
            if (sound.status == "Paused")
                sound.controls.play();
        }
    }
}
