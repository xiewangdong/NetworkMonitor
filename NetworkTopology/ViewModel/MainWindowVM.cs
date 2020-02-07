using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NetworkTopology.Model;
using NetworkTopology.View;

namespace NetworkTopology.ViewModel
{
    public class MainWindowVM : ViewModelBase
    {
        #region 属性
        public ObservableCollection<DeviceVM> DeviceItems { get; set; } //已添加的设备集合
        System.Windows.Point mousePosition = new System.Windows.Point();    //保存鼠标右键点击位置
        public List<DeviceItem> DeviceList { get; set; }    //可选设备集合
        #endregion

        //构造函数
        public MainWindowVM()
        {
            DeviceItems = new ObservableCollection<DeviceVM>();
            DeviceList = new List<DeviceItem>()
            {
                new DeviceItem(){Name="防火墙",UpSource="pack://application:,,,/Resources/Images/firewall.png",DownSource="pack://application:,,,/Resources/Images/firewall_down.png"},
                new DeviceItem(){Name="摄像头",UpSource="pack://application:,,,/Resources/Images/camera.png",DownSource="pack://application:,,,/Resources/Images/camera_down.png"},
                new DeviceItem(){Name="计算机",UpSource="pack://application:,,,/Resources/Images/monitor.png",DownSource="pack://application:,,,/Resources/Images/monitor_down.png"},
                new DeviceItem(){Name="路由器",UpSource="pack://application:,,,/Resources/Images/router.png",DownSource="pack://application:,,,/Resources/Images/router_down.png"},
                new DeviceItem(){Name="服务器",UpSource="pack://application:,,,/Resources/Images/server.png",DownSource="pack://application:,,,/Resources/Images/server_down.png"},
                new DeviceItem(){Name="交换机",UpSource="pack://application:,,,/Resources/Images/switch.png",DownSource="pack://application:,,,/Resources/Images/switch_down.png"},
            };
        }

        #region 命令
        public RelayCommand addDeviceCmd { get; set; }  //“添加设备”命令
        public RelayCommand AddDeviceCmd
        {
            get
            {
                if (addDeviceCmd == null)
                    addDeviceCmd = new RelayCommand(AddDevice);
                return addDeviceCmd;
            }
        }
        public RelayCommand addLineCmd { get; set; }    //“添加连线”命令
        public RelayCommand AddLineCmd
        {
            get
            {
                if (addLineCmd == null)
                    addLineCmd = new RelayCommand(AddLine);
                return addLineCmd;
            }
        }
        private RelayCommand<Canvas> markMousePositionCmd;  //标记鼠标右键点击位置命令

        public RelayCommand<Canvas> MarkMousePositionCmd
        {
            get
            {
                if (markMousePositionCmd == null)
                    markMousePositionCmd = new RelayCommand<Canvas>(x => MarkMousePosition(x));
                return markMousePositionCmd;
            }
        }

        #endregion

        /// <summary>
        /// 添加连线
        /// </summary>
        private void AddLine()
        {
            MessageBox.Show("AddLine");
        }
        /// <summary>
        /// 添加设备
        /// </summary>
        private void AddDevice()
        {
            DeviceInfoDlg dlg = new DeviceInfoDlg();
            DeviceVM dv = new DeviceVM()
            {
                DeviceList = this.DeviceList,
                Left = mousePosition.X,
                Top = mousePosition.Y
            };
            dlg.DataContext = dv;
            if ((bool)dlg.ShowDialog())
            {
                DeviceItems.Add(dv);
            }
        }
        /// <summary>
        /// 标记鼠标点击坐标
        /// </summary>
        /// <param name="cv"></param>
        private void MarkMousePosition(Canvas cv)
        {
            mousePosition = Mouse.GetPosition(cv);
        }
    }

}
