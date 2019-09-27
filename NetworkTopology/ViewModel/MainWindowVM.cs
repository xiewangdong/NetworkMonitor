using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace NetworkTopology.ViewModel
{
    public class MainWindowVM : ViewModelBase
    {
        public RelayCommand AddDeviceCmd { get; set; }  //“添加设备”命令
        public RelayCommand AddLineCmd { get; set; }    //“添加连线”命令


        public MainWindowVM()
        {
            AddDeviceCmd = new RelayCommand(new Action(AddDevice));
            AddLineCmd = new RelayCommand(new Action(AddLine));
        }

        //添加连线
        private void AddLine()
        {
            throw new NotImplementedException();
        }
        //添加设备
        private void AddDevice()
        {
            throw new NotImplementedException();
        }
    }
}
