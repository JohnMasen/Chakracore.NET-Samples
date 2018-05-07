using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChakraCore.NET.Hosting;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace SimpleChart.UWP.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private jsApp app;
        public MainViewModel()
        {
            
        }
        public float GetNextValue() => app.GetNext();
        public IEnumerable<StorageFolder> Folders { get; private set; }
        /// <summary>
        /// The <see cref="Info" /> property's name.
        /// </summary>
        public const string InfoPropertyName = "Info";

        private string _info = string.Empty;

        /// <summary>
        /// Sets and gets the Info property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Info
        {
            get
            {
                return _info;
            }

            set
            {
                if (_info == value)
                {
                    return;
                }

                _info = value;
                RaisePropertyChanged(() => Info);
            }
        }
        private StorageFolder RootFolder;
        public StorageFolder SelectedItem { get; set; }
        public RelayCommand ChooseRoot => new RelayCommand(async () =>
        {
            FolderPicker picker = new FolderPicker();
            picker.FileTypeFilter.Add("*");
            RootFolder = await picker.PickSingleFolderAsync();
            if (RootFolder != null)
            {
                Folders = await RootFolder.GetFoldersAsync();

                RaisePropertyChanged(nameof(Folders));

            }


        });
        internal DataStrip Data { get; } = new DataStrip(200);
        public event EventHandler<bool> IsPauseChanged;
        public void NextStep()
        {
            Data.Add(app.GetNext());
        }
        public RelayCommand Run => new RelayCommand(() =>
          {
              if (SelectedItem!=null)
              {
                  IsPauseChanged?.Invoke(this, true);
                  Data.Clear();

                  JavaScriptHostingConfig config = new JavaScriptHostingConfig();
                  config.AddModuleFolder(SelectedItem);
                  config.AddModuleFolder(RootFolder);
                  app = JavaScriptHosting.Default.GetModuleClass<jsApp>("app", "app", config);
                  
                  IsPauseChanged?.Invoke(this, false);
              }
          });


        private class jsApp:ChakraCore.NET.Hosting.JSClassWrapperBase
        {
            public float GetNext()
            {
                return Reference.CallFunction<float>("next");
            }
        }


    }
}