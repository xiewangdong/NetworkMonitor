using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NetworkTopology.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NetworkTopology.ViewModel
{
    public class DeviceVM : ViewModelBase
    {
        public List<DeviceItem> DeviceList { get; set; }    //可选设备集合

        private DeviceItem deviceItem;  //设备类型信息

        public DeviceItem DeviceItem
        {
            get { return deviceItem; }
            set { deviceItem = value; }
        }

        private string deviceName;  //设备名称

        public string DeviceName
        {
            get { if (string.IsNullOrEmpty(deviceName)) deviceName = "未知设备"; return deviceName; }
            set { deviceName = value; }
        }

        private string ip;  //设备IP地址

        public string IP
        {
            get { return ip; }
            set { ip = value; }
        }


        private double left;   //设备Canvas布局中Left属性

        public double Left
        {
            get { return left; }
            set { left = value; RaisePropertyChanged("Left"); }
        }

        private double top;    //设备Canvas布局中Top属性

        public double Top
        {
            get { return top; }
            set { top = value; RaisePropertyChanged("Top"); }
        }

        private RelayCommand<Thumb> dragStartedCmd; //拖动开始命令

        public RelayCommand<Thumb> DragStartedCmd
        {
            get
            {
                if (dragStartedCmd == null)
                    dragStartedCmd = new RelayCommand<Thumb>(x => DragStarted(x));
                return dragStartedCmd;
            }
        }
        private Point DragStartedPoint; //存储拖动开始鼠标相对设备的坐标
        /// <summary>
        /// 拖动开始函数，保存拖动开始鼠标相对设备的坐标
        /// </summary>
        /// <param name="x"></param>
        private void DragStarted(Thumb x)
        {
            DragStartedPoint = Mouse.GetPosition(x);
        }

        private RelayCommand<Canvas> dragDeltaCmd;  //拖动命令

        public RelayCommand<Canvas> DragDeltaCmd
        {
            get
            {
                if (dragDeltaCmd == null)
                    dragDeltaCmd = new RelayCommand<Canvas>(x => DragDelta(x));
                return dragDeltaCmd;
            }
        }
        /// <summary>
        /// 拖动函数，使控件随鼠标移动
        /// </summary>
        /// <param name="x"></param>
        private void DragDelta(Canvas x)
        {
            Point p = Mouse.GetPosition(x);
            Left = p.X - DragStartedPoint.X;
            Top = p.Y - DragStartedPoint.Y;
            
        }

        private RelayCommand<Window> okCmd; //设备信息窗口“确认”按钮命令

        public RelayCommand<Window> OkCmd
        {
            get
            {
                if (okCmd == null)
                    okCmd = new RelayCommand<Window>(x=>OK(x));
                return okCmd;
            }
        }
        /// <summary>
        /// 返回DialogResult为true，并关闭窗口
        /// </summary>
        /// <param name="window"></param>
        private void OK(Window window)
        {
            window.DialogResult = true;
            window.Close();
        }

        public DeviceVM()
        {
        }
    }
}
