using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Osciloscop
{
    public partial class Form1 : Form
    {
        private byte[] SignalRecv = new byte[1600];

        private int[] SignalShow = new int[1600];
        private int[] TriggerShow = new int[1600];
        private bool Slope;

        private bool recvStarted;
        private bool recvEnded;

        private byte[] recvFullline = new byte[5000];
        private int recvIndex;

        private byte XVal;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ports = System.IO.Ports.SerialPort.GetPortNames();
            COMPorts.DataSource = ports;

            for (int i = 0; i < COMPorts.Items.Count; i++)
            {
                if (COMPorts.Items[i].ToString() == Properties.Settings.Default["com_port"].ToString())
                    COMPorts.SelectedIndex = i;
            }

            XVal = 0;
            Slope = false;
            TriggerTrackbar.Value = 0;
            TriggerTrackbar_ValueChanged(sender, e);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default["com_port"] = COMPorts.Text;
            Properties.Settings.Default.Save();
        }

        private void UpdateChart()
        {
            chart1.Series["ValueLine"].Points.Clear();

            for (int i = 0; i < 1600; i++)
            {
                chart1.Series["ValueLine"].Points.AddXY(i, SignalRecv[i]);
            }
        }

        private void COMConnectBtn_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen == false)
            {
                //connect the unit
                serialPort.BaudRate = 57600;
                serialPort.Parity = System.IO.Ports.Parity.None;
                serialPort.StopBits = System.IO.Ports.StopBits.One;
                serialPort.RtsEnable = false;
                serialPort.PortName = COMPorts.Items[COMPorts.SelectedIndex].ToString();
                serialPort.DtrEnable = false;
                serialPort.DataBits = 8;
                serialPort.Open();
            }
            else
            {
                serialPort.Close();
            }
        }

        private void InterfaceTimer_Tick(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                COMConnectBtn.Text = "Disconnect";
                SnapshotTimer.Enabled = true;
            }
            else
                COMConnectBtn.Text = "Connect";

            chart1.ChartAreas[0].AxisX.Title = "Samples at " + (1000 / (1 << XVal ) ).ToString() + " KSPS";
        }

        private void serialTimer_Tick(object sender, EventArgs e)
        {
            byte[] recv = new byte[2001];
            int l;

            if (serialPort.IsOpen == false)
                return;

            try
            {
                l = serialPort.Read(recv, 0, 2000);
            }
            catch (TimeoutException) { l = 0; }


            while (l > 0)
            {

                for (int i = 0; i < l; i++)
                {

                    if (recvStarted)
                    {

                        recvFullline[recvIndex++] = recv[i];

                        //look for 'end'
                        if (recvIndex > 2)
                        {
                            if ((recvFullline[recvIndex - 3] == 'e') && (recvFullline[recvIndex - 2] == 'n') && (recvFullline[recvIndex - 1] == 'd'))
                            {
                                recvEnded = true;
                                recvStarted = false;

                                //process the line :D
                                switch (recvFullline[3])
                                {

                                    case 0xA0:
                                        //parse it

                                        for (int j = 4; j < 1604; j++)
                                            SignalRecv[j - 4] = recvFullline[j];

                                        UpdateChart();
                                        break;


                                }

                            }
                        }
                    }
                    else
                    {
                        if (i > 1)
                        {
                            //look for 'snp'
                            if ((recv[i - 2] == 's') && (recv[i - 1] == 'n') && (recv[i] == 'p'))
                            {
                                recvStarted = true;
                                recvIndex = 0;
                                recvFullline[recvIndex++] = recv[i - 2];
                                recvFullline[recvIndex++] = recv[i - 1];
                                recvFullline[recvIndex++] = recv[i];
                            }
                        }
                    }

                }

                try
                {
                    l = serialPort.Read(recv, 0, 2000);
                }
                catch (TimeoutException) { l = 0; }
            }
        }

        private void SnapshotTimer_Tick(object sender, EventArgs e)
        {
            if(serialPort.IsOpen)
            {
                byte[] command = new byte[10];
                command[0] = 's' - 0;
                command[1] = 'n' - 0;
                command[2] = 'p' - 0;
                if(Slope == true)
                    command[3] = '1' - 0;
                else
                    command[3] = '0' - 0;
                command[4] = Convert.ToByte(TriggerTrackbar.Value);
                command[5] = XVal;
                command[6] = 'y' - 0;
                command[7] = 'e' - 0;
                command[8] = 'n' - 0;
                command[9] = 'd' - 0;
                
                serialPort.Write(command, 0, 10);
            }
        }

        private void SlopeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(Slope == false)
            {
                Slope = true;
                SlopeLink.Text = "Negative";
            }
            else
            {
                Slope = false;
                SlopeLink.Text = "Positive";
            }
        }

        private void TriggerTrackbar_ValueChanged(object sender, EventArgs e)
        {
            chart1.Series["TriggerLine"].Points.Clear();
            for (int i = 0; i < 1600; i++)
                chart1.Series["TriggerLine"].Points.AddXY(i, TriggerTrackbar.Value);
        }

        private void XValPlus_Click(object sender, EventArgs e)
        {
            if (XVal > 0)
                XVal--;
        }

        private void XValMinus_Click(object sender, EventArgs e)
        {
            if (XVal < 6)
                XVal++;
        }

        private void HorizScale_ValueChanged(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Maximum = HorizScale.Value;
        }
    }
}
