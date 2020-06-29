using WMPLib;

namespace CaroTest.Setting
{
    class SoundManager
    {
        private WindowsMediaPlayer sound;
        public SoundManager()
        {
            sound = new WindowsMediaPlayer();
        }

        public bool IsLoop
        {
            get { return sound.settings.getMode("loop"); }
            set { sound.settings.setMode("loop", value); }
        }

        public int Volume
        {
            get { return sound.settings.volume; }
            set { sound.settings.volume = value; }
        }

        public void Play(string url)
        {
            sound.URL = url;
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
