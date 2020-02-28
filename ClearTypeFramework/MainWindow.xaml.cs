using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClearTypeTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            TextRenderingModes.Add(TextRenderingMode.Aliased);
            TextRenderingModes.Add(TextRenderingMode.Auto);
            TextRenderingModes.Add(TextRenderingMode.ClearType);
            TextRenderingModes.Add(TextRenderingMode.Grayscale);

            CurrentTextRenderingMode = TextRenderingMode.Auto;

            TextFormattingModes.Add(TextFormattingMode.Display);
            TextFormattingModes.Add(TextFormattingMode.Ideal);

            CurrentTextFormattingMode = TextFormattingMode.Ideal;

            foreach (var font in System.Windows.Media.Fonts.SystemFontFamilies)
            {
                Fonts.Add(font);
            }

            CurrentFont = Fonts[0];

            for (int i = 8; i < 100; i++)
            {
                FontSizes.Add(i);
            }

            CurrentFontSize = 12;

        }

        private TextFormattingMode _currentTextFormattingMode;
        public TextFormattingMode CurrentTextFormattingMode
        {
            get { return _currentTextFormattingMode; }
            set { _currentTextFormattingMode = value; RaisePropertyChanged("CurrentTextFormattingMode"); }
        }

        public ObservableCollection<TextFormattingMode> TextFormattingModes { get; set; } = new ObservableCollection<TextFormattingMode>();

        private TextRenderingMode _currentTextRenderingMode;
        public TextRenderingMode CurrentTextRenderingMode
        {
            get { return _currentTextRenderingMode; }
            set { _currentTextRenderingMode = value; RaisePropertyChanged("CurrentTextRenderingMode"); }
        }

        public ObservableCollection<TextRenderingMode> TextRenderingModes { get; set; } = new ObservableCollection<TextRenderingMode>();

        private FontFamily _font;
        public FontFamily CurrentFont
        {
            get
            { return _font; }
            set
            {
                _font = value;
                RaisePropertyChanged("CurrentFont");
            }
        }

        private int _fontSize;
        public int CurrentFontSize
        {
            get
            { return _fontSize; }
            set
            {
                _fontSize = value;
                RaisePropertyChanged("CurrentFontSize");
            }
        }

        public ObservableCollection<FontFamily> Fonts { get; set; } = new ObservableCollection<FontFamily>();

        public ObservableCollection<int> FontSizes { get; set; } = new ObservableCollection<int>();

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
