using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.Graphics.Capture;



using Windows.UI.Composition;
using System.Numerics;
using ContainerVisual = Windows.UI.Composition.ContainerVisual;
using CompositionTarget = Windows.UI.Composition.CompositionTarget;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using System.Windows.Threading;
using System.Windows.Controls.Primitives;

namespace MORT.ScreenCapture
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PopupScreenCapture : Window
    {
        public PopupScreenCapture()
        {
            InitializeComponent();
        }

        public bool isClosed = false;

        private IntPtr hwnd;
        private Action callback;
        private Action closeCallback;
        private Action stopCallback;

        private string _waitingAttach = "상태 : 윈도우 선택중";
        private string _attachError = "해당 윈도우는 캡쳐할 수 없습니다" + System.Environment.NewLine + "윈도우가 활성화 되어 있는지 확인해 주세요";
        private string _attachComplete = "상태 : 캡쳐 중 - ";
        private string _stopAttach = "상태 : 캡쳐 중지";

        private string _borderEnable = "노란색 테두리 활성화";
        private string _borderDisable = "노란색 테두리 비활성화";
        private string _borderForceEnable = "노란색 테두리 활성화 (비활성화는 윈도우11에서만 가능)";

        private ScreenCapture sample;
        private bool _enableYellowBoard;

        private async Task PrepareCaptureAsync()
        {
            lbInfo.Content = _waitingAttach;
            var interopWindow = new WindowInteropHelper(this);
            hwnd = interopWindow.Handle;
            var picker = new GraphicsCapturePicker();
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hwnd);
            //window.Initialize(hwnd);
            var item = await picker.PickSingleItemAsync();

            if (item != null)
            {
                IntPtr hWnd = GethWnd(item.DisplayName);

                if (hWnd == IntPtr.Zero)
                {
                    if (MessageBox.Show(_attachError, LocalizeManager.LocalizeManager.GetLocalizeString("Error Title"), MessageBoxButton.OK) == MessageBoxResult.OK)
                    {
                        Close();
                    }
                }
                else
                {
                    item.Closed += (s, a) =>
                    {
                        StopCapture();
                    };
                    BorderStateType borderStateType = BorderStateType.None;

                    lbBorderInfo.Content = "";

                    sample.StartCaptureFromItem(item, hWnd, _enableYellowBoard, out borderStateType);
                    callback();

                    lbInfo.Content = $"{_attachComplete} - {item.DisplayName}";

                    switch (borderStateType)
                    {
                        case BorderStateType.Enable:
                            lbBorderInfo.Content = _enableYellowBoard;
                            break;

                        case BorderStateType.Disable:
                            lbBorderInfo.Content = _borderDisable;
                            break;

                        case BorderStateType.ForceEnable:
                            lbBorderInfo.Content = _borderForceEnable;
                            break;
                    }
                }
            }
            else
            {
                Close();
            }
        }

        private void Localize()
        {
            this.Title = LocalizeManager.LocalizeManager.GetLocalizeString("Attach Popup Title");

            btAttach.Content = LocalizeManager.LocalizeManager.GetLocalizeString("Attach Start Button");
            btStop.Content = LocalizeManager.LocalizeManager.GetLocalizeString("Attach Stop Button");

            _waitingAttach = LocalizeManager.LocalizeManager.GetLocalizeString("Attach Waiting");
            _attachError = $"{LocalizeManager.LocalizeManager.GetLocalizeString("Attach Error")}\n{LocalizeManager.LocalizeManager.GetLocalizeString("Attach Error2")}";
            _attachComplete = LocalizeManager.LocalizeManager.GetLocalizeString("Attach Complete");
            _stopAttach = LocalizeManager.LocalizeManager.GetLocalizeString("Attach Stop");
            _borderEnable = LocalizeManager.LocalizeManager.GetLocalizeString("Attach BorderEnable");
            _borderDisable = LocalizeManager.LocalizeManager.GetLocalizeString("Attach BorderDisable");
            _borderForceEnable = LocalizeManager.LocalizeManager.GetLocalizeString("Attach BorderForceEnable");
        }

        public void Start(Action callback, Action closeCallback, Action stopCallback, bool enableYellowBoard)
        {
            _enableYellowBoard = enableYellowBoard;
            this.callback = callback;
            this.closeCallback = closeCallback;
            this.stopCallback = stopCallback;
            Localize();

            PrepareCaptureAsync();
        }

        public void StopCapture()
        {
            lbInfo.Content = _stopAttach;
            sample.StopCapture();

            if (stopCallback != null)
            {
                stopCallback();
            }
        }

        public void DoPrepare()
        {
            sample.PrepareStart();
        }
        public void DoCapture()
        {
            sample.StartDataCapture();
        }

        public bool GetData(ref byte[] array, ref int x, ref int y, ref int positionX, ref int positionY)
        {
            bool isSuccess = sample.GetData(ref array, ref x, ref y, ref positionX, ref positionY);

            return isSuccess;
        }


        private IntPtr GethWnd(string name)
        {

            IntPtr hWnd = IntPtr.Zero;
            var processesWithWindows = from p in Process.GetProcesses()
                                       where !string.IsNullOrWhiteSpace(p.MainWindowTitle) && WindowEnumerationHelper.IsWindowValidForCapture(p.MainWindowHandle)
                                       select p;
            try
            {

                ObservableCollection<Process> processes = new ObservableCollection<Process>(processesWithWindows);


                foreach (var p in processes)
                {
                    Console.WriteLine(p.MainWindowTitle);

                    if (p.MainWindowTitle == name)
                    {
                        hWnd = p.MainWindowHandle;
                        Console.WriteLine("!!!!!!GEt!!!!!!!!!!! " + p.MainWindowTitle);
                    }

                    Console.WriteLine("Names " + p.MainWindowTitle);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return hWnd; //Should contain the handle but may be zero if the title doesn't match
        }




        private void InitComposition()
        {
            sample = new ScreenCapture();
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            isClosed = true;
            if (sample != null)
            {
                sample.Dispose();
            }

            if (closeCallback != null)
            {
                closeCallback();
            }

        }

        private void btAttach_Click(object sender, RoutedEventArgs e)
        {
            PrepareCaptureAsync();
        }

        private void btStop_Click(object sender, RoutedEventArgs e)
        {
            StopCapture();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            InitComposition();

        }

        private void Window_Closed_1(object sender, EventArgs e)
        {
            isClosed = true;
        }
    }
}
