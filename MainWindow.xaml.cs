using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IViewFor<MainWindowViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty
            .Register(nameof(ViewModel), typeof(MainWindowViewModel), typeof(MainWindow));

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainWindowViewModel();

            // Setup the bindings
            // Note: We have to use WhenActivated here, since we need to dispose the
            // bindings on XAML-based platforms, or else the bindings leak memory.
            this.WhenActivated(disposable =>
            {
                this.Bind(this.ViewModel, x => x.TheText, x => x.TheTextBox.Text)
                    .DisposeWith(disposable);
                this.OneWayBind(this.ViewModel, x => x.TheText, x => x.TheTextBlock.Text)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.TheTextCommand, x => x.TheTextButton)
                    .DisposeWith(disposable);
            });
            
        }

        public MainWindowViewModel ViewModel
        {
            get => (MainWindowViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (MainWindowViewModel)value;
        }
    }
}
