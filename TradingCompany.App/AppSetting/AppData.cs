using System.Drawing;

namespace TradingCompany.App.AppSetting
{
    class AppData
    {
        public static string Color1Property = nameof(Color1);
        public Color? Color1 { get; set; }

        public static string Color2Property = nameof(Color2);
        public Color? Color2 { get; set; }
    }
}
