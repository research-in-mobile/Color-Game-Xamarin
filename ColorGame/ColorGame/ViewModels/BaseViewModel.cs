using ColorGame.DTOs;
using ColorGame.Helpers;
using ColorGame.Services;
using ColorGame.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace ColorGame.ViewModels
{
    public class BaseViewModel : BaseBindable
    {
        string _title = string.Empty;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public Command StartGameCommand { get; set; }
        public Command GoBackCommand { get; set; }
        public Command<string> GoToCommand { get; set; }

        protected readonly IErrorManagementService _errorManagementService;
        protected readonly INavigationService _navigationService;
        public BaseViewModel()
        {
            _navigationService = DependencyService.Resolve<INavigationService>();
            _errorManagementService = DependencyService.Resolve<IErrorManagementService>();

            GoToCommand = new Command<string>(value => GoTo(value));
            GoBackCommand = new Command(GoBack);
            StartGameCommand = new Command(value => GoTo($"{nameof(GamePage)}", true));
        }

        public virtual void GoBack()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                using (Busy())
                    await Shell.Current.GoToAsync("..", true);

            });
        }
        public virtual void GoTo(string pagePath, bool hasAnimation = true)
        {
            if (IsBusy) return;

            Shell.Current.FlyoutIsPresented = false;

            Device.BeginInvokeOnMainThread(async () =>
            {
                using (Busy())
                    await Shell.Current.GoToAsync(pagePath, hasAnimation).ConfigureAwait(false);
            });
        }

        #region Busy Mechanism
        private static readonly Guid _defaultTracker = new Guid(AppSettings.AppBusyLockKey);
        private IList<Guid> _busyLocks = new List<Guid>();

        public bool IsBusy
        {
            get => _busyLocks.Any();
            set
            {
                if (value && !_busyLocks.Contains(_defaultTracker))
                {
                    _busyLocks.Add(_defaultTracker);
                    RaisePropertyChanged(nameof(IsBusy));
                }

                if (!value && _busyLocks.Contains(_defaultTracker))
                {
                    _busyLocks.Remove(_defaultTracker);
                    RaisePropertyChanged(nameof(IsBusy));
                }
            }
        }

        protected BusyHelper Busy() => new BusyHelper(this);

        protected void ForceUnlock()
        {
            _busyLocks = new List<Guid>();
        }

        protected bool IsThreadLocked = false;

        protected sealed class BusyHelper : IDisposable
        {
            private readonly BaseViewModel _viewModel;
            private readonly Guid _tracker;

            public BusyHelper(BaseViewModel viewModel)
            {
                _viewModel = viewModel;
                _tracker = Guid.NewGuid();
                _viewModel._busyLocks.Add(_tracker);
                _viewModel.RaisePropertyChanged(nameof(IsBusy));
            }

            public void Dispose()
            {
                _viewModel._busyLocks.Remove(_tracker);
                _viewModel.RaisePropertyChanged(nameof(IsBusy));
            }
        }
        #endregion
    }
}
