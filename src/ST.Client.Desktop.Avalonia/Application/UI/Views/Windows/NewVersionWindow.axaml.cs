using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Application.UI.ViewModels;

namespace System.Application.UI.Views.Windows
{
    public class NewVersionWindow : FluentWindow
    {
        public Button BtnCancel { get; }

        public NewVersionWindow() : base(false)
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            BtnCancel = this.FindControl<Button>(nameof(BtnCancel));
            BtnCancel.Click += (_, _) => Close();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}