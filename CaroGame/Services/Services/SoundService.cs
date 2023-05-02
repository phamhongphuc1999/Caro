using WMPLib;

namespace CaroGame.Services.Services
{
  public class SoundService
  {
    private WindowsMediaPlayer sound;
    public SoundService()
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
