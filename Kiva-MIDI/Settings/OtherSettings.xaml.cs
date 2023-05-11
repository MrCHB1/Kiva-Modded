using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
//using System.Windows.Shapes;

namespace Kiva_MIDI
{
    /// <summary>
    /// Interaction logic for OtherSettings.xaml
    /// </summary>
    public partial class OtherSettings : UserControl
    {
        private Settings settings;
        List<Dictionary<string, ResourceDictionary>> Languages = new List<Dictionary<string, ResourceDictionary>>();

        public Settings Settings
        {
            get => settings; set
            {
                settings = value;
                SetValues();
            }
        }

        public OtherSettings()
        {
            InitializeComponent();

            // get language and stuff idk (code is from zenith)
            var languagePacks = Directory.GetDirectories("Languages");
            foreach (var language in languagePacks)
            {
                var resources = Directory.GetFiles(language).Where((l) => l.EndsWith(".xaml")).ToList();
                if (resources.Count == 0) continue;

                Dictionary<string, ResourceDictionary> fullDict = new Dictionary<string, ResourceDictionary>();
                foreach (var r in resources)
                {
                    ResourceDictionary file = new ResourceDictionary();
                    file.Source = new Uri(Path.GetFullPath(r), UriKind.RelativeOrAbsolute);
                    var name = Path.GetFileNameWithoutExtension(r);
                    fullDict.Add(name, file);
                }
                if (!fullDict.ContainsKey("window")) continue;
                if (fullDict["window"].Contains("LanguageName") && fullDict["window"]["LanguageName"].GetType() == typeof(string))
                    Languages.Add(fullDict);
            }
        }

        void SetValues()
        {
            LangaugeSelect.SelectedItem = settings.General.SelectedLanguage;
        }

        private void LangaugeSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (LangaugeSelect.SelectedItem)
            {
                case "English":
                    {
                        SetLanguage(0);
                        break;
                    }
            }
        }

        private void SetLanguage(int langIdx)
        {
            //Console.WriteLine(Application.Current.Resources["visualTab"]);
            Application.Current.Resources.MergedDictionaries[0].MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries[0].MergedDictionaries.Add(Languages[0]["window"]);
            Application.Current.Resources.MergedDictionaries[0].MergedDictionaries.Add(Languages[langIdx]["window"]);
        }
    }
}
