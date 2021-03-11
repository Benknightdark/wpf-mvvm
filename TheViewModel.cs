using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
   public  class MainWindowViewModel : ReactiveObject
    {
        private string theText;
        public string TheText
        {
            get => theText;
            set => this.RaiseAndSetIfChanged(ref this.theText, value);
        }

        public ReactiveCommand<Unit, Unit> TheTextCommand { get; }

        public MainWindowViewModel()
        {
            TheTextCommand = ReactiveCommand
                .CreateFromObservable(ExecuteTextCommand);
        }

        private IObservable<Unit> ExecuteTextCommand()
        {
            TheText = "Hello ReactiveUI";
            return Observable.Return(Unit.Default);
        }
    }
}
