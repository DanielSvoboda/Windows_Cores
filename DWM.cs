using System.Runtime.InteropServices;


namespace Windows_Cores
{
    class DWM
    {
        [DllImport("uxtheme", EntryPoint = "#122")]
        static extern int SetUserColorPreference(ref IMMERSIVE_COLOR_PREFERENCE pcpPreference, bool fForceSetting);

        [DllImport("dwmapi.dll", EntryPoint = "#127", PreserveSig = false)]
        private static extern void DwmGetColorizationParameters(out DWM_COLORIZATION_PARAMS parameters);

        [DllImport("dwmapi.dll", EntryPoint = "#131", PreserveSig = false)]
        private static extern void DwmSetColorizationParameters(ref DWM_COLORIZATION_PARAMS parameters, bool unknown);



        private struct DWM_COLORIZATION_PARAMS
        {
            public uint clrColor;
            public uint clrAfterGlow;
            public uint nIntensity;
            public uint clrAfterGlowBalance;
            public uint clrBlurBalance;
            public uint clrGlassReflectionIntensity;
            public bool fOpaque;
        }


        public static void Refresh()
        {
            DWM_COLORIZATION_PARAMS tmp;
            DwmGetColorizationParameters(out tmp);
            DwmSetColorizationParameters(ref tmp, false);
        }


        [StructLayout(LayoutKind.Sequential)]
        private struct IMMERSIVE_COLOR_PREFERENCE
        {
            public uint crAccentColor;
            public uint crStartColor;
            public uint dwColorSetIndex;
        }


        public static void SetAccentColor(uint cor)
        {
            IMMERSIVE_COLOR_PREFERENCE temp = new IMMERSIVE_COLOR_PREFERENCE
            {
                crAccentColor = cor,
                dwColorSetIndex = 0,
                crStartColor = cor
            };
            SetUserColorPreference(ref temp, true);
        }
    }
}
