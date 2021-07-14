﻿using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using ViewModelsSamples.Bars.AutoUpdate;

namespace WinUISample.Bars.AutoUpdate
{
    public sealed partial class View : UserControl
    {
        private bool? _isStreaming = false;

        public View()
        {
            InitializeComponent();
        }

        private async void Button_PointerPressed(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            var vm = (ViewModel)DataContext;
            _isStreaming = _isStreaming is null ? true : !_isStreaming;

            while (_isStreaming.Value)
            {
                vm.RemoveFirstItem();
                vm.AddRandomItem();
                await Task.Delay(1000);
            }
        }
    }
}