using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace COM_Terminal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerialPort serialPort1 = new SerialPort();
        Queue<string> commandQueue = new Queue<string>();
        private DispatcherTimer timer = null;
        private int x;

        public MainWindow()
        {
            InitializeComponent();
            serialPort1.DataReceived += serialPort1_DataReceived;
            SetPortName();
            buttonDisconnect.IsEnabled = false;
            buttonSend.IsEnabled = false;
            textBoxMessage.IsEnabled = false;
            buttonFromFile.IsEnabled = false;

            //Установка заначений по умолчанию
            comboBoxBaudRate.SelectedIndex = 3;
            serialPort1.BaudRate = 9600;
            comboBoxParity.SelectedIndex = 2;
            serialPort1.Parity = Parity.None;
            comboBoxStopBits.SelectedIndex = 1;
            serialPort1.StopBits = StopBits.One;

            comboBoxTimeOut.SelectedIndex = 1;

            serialPort1.DataBits = 8;
            serialPort1.ReadTimeout = 500;
        }

        public void SetPortName()
        {
            foreach (string portname in SerialPort.GetPortNames())
                comboBoxPort.Items.Add(portname);    
            
            comboBoxPort.SelectedIndex = 0;
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(100);
            string readstring = String.Empty;
            bool isBinaryMode = false;

            this.Dispatcher.Invoke(() =>
            {
                isBinaryMode = (bool)CBBinaryMode.IsChecked;
            });

            try
            {
                //readstring = serialPort1.ReadLine();
                //readstring = serialPort1.ReadTo(">");

                while (serialPort1.BytesToRead != 0)
                {
                    System.Threading.Thread.Sleep(10);


                    if (isBinaryMode)
                    {
                        readstring += serialPort1.ReadByte().ToString() + " ";
                    }
                    else
                    {
                        readstring += Convert.ToChar(serialPort1.ReadByte()).ToString();
                    }
                }
            }
            catch (TimeoutException)
            {
            }
            
            this.Dispatcher.Invoke(() =>
            {
                textBoxData.AppendText("> " + readstring + Environment.NewLine);
                textBoxData.ScrollToEnd();
            });
        }

        private void buttonSend_Click(object sender, RoutedEventArgs e)
        {
            Send(textBoxMessage.Text);
        }

        private void Send (string Message)
        {
            try
            {
                serialPort1.WriteLine(Message + Environment.NewLine);
                textBoxMessage.Clear();

                textBoxData.AppendText(Message + Environment.NewLine);
                textBoxData.ScrollToEnd();
            }
            catch (TimeoutException)
            {
                MessageBox.Show("TimeoutException");
            }
        }

        private void buttonConnect_Click(object sender, RoutedEventArgs e)
        {
            serialPort1.PortName = ((string)comboBoxPort.SelectedItem);

            switch (comboBoxBaudRate.SelectedIndex)
            {
                case 0: serialPort1.BaudRate = 1200; break;
                case 1: serialPort1.BaudRate = 2400; break;
                case 2: serialPort1.BaudRate = 4800; break;
                case 3: serialPort1.BaudRate = 9600; break;
                case 4: serialPort1.BaudRate = 19200; break;
                case 5: serialPort1.BaudRate = 38400; break;
                case 6: serialPort1.BaudRate = 57600; break;
                case 7: serialPort1.BaudRate = 115200; break;
            }

            switch (comboBoxParity.SelectedIndex)
            {
                case 0: serialPort1.Parity = Parity.Even; break;
                case 1: serialPort1.Parity = Parity.Mark; break;
                case 2: serialPort1.Parity = Parity.None; break;
                case 3: serialPort1.Parity = Parity.Odd; break;
                case 4: serialPort1.Parity = Parity.Space; break;
            }

            switch (comboBoxStopBits.SelectedIndex)
            {
                case 0: serialPort1.StopBits = StopBits.None; break;
                case 1: serialPort1.StopBits = StopBits.One; break;
                case 2: serialPort1.StopBits = StopBits.OnePointFive; break;
                case 3: serialPort1.StopBits = StopBits.Two; break;
            }

            try
            {
                if(!serialPort1.IsOpen)
                    serialPort1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (serialPort1.IsOpen)
            {
                buttonConnect.IsEnabled = false;
                buttonDisconnect.IsEnabled = true;
                buttonSend.IsEnabled = true;
                textBoxMessage.IsEnabled = true;
                buttonFromFile.IsEnabled = true;
            }
        }

        private void buttonDisconnect_Click(object sender, RoutedEventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
            if (!serialPort1.IsOpen)
            {
                buttonConnect.IsEnabled = true;
                buttonDisconnect.IsEnabled = false;
                buttonSend.IsEnabled = false;
                textBoxMessage.IsEnabled = false;
                buttonFromFile.IsEnabled = false;
            }
        }

        private void TextBoxMessage_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Send(textBoxMessage.Text);
            }
        }

        private void ButtonFromFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string[] allStr = File.ReadAllLines(openFileDialog.FileName);
                foreach (string command in allStr)
                {
                    commandQueue.Enqueue(command);
                }
                timerStart();
            }
        }

        private void timerStart()
        {
            int timeOut = 3000;
            switch (comboBoxTimeOut.SelectedIndex)
            {
                case 0: timeOut = 1000; break;
                case 1: timeOut = 3000; break;
                case 2: timeOut = 5000; break;
            }
            timer = new DispatcherTimer();  // если надо, то в скобках указываем приоритет, например DispatcherPriority.Render
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, timeOut);
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            Send(commandQueue.Dequeue());
            if (commandQueue.Count == 0) timer.Stop();
        }

        private void MenuItem_Click_Save(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Текстовый файл|*.txt";

            if (saveFileDialog.ShowDialog() == true)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.WriteLine(textBoxData.Text);
                streamWriter.Close();
            }
        }

        private void MenuItem_Click_Clear(object sender, RoutedEventArgs e)
        {
            textBoxData.Clear();
        }
    }
}
