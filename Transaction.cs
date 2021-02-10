using System.Linq;
using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;

namespace MuteMicrophone
{
    static class Transaction
    {
        static CoreAudioController audioController = new CoreAudioController();
        private static CoreAudioDevice device = null;
        public static void GetMicAsync()
        {
            if (device == null)
            {
                var devices = audioController.GetCaptureDevices(DeviceState.Active);
                device = devices.FirstOrDefault(x => x.IsDefaultDevice);
            }

        }

        public static void MuteUnMute()
        {
            if (device.IsMuted)
                device.Mute(false);
            else
                device.Mute(true);

        }

        public static bool isMute()
        {
            return device.IsMuted;
        }
    }
}
