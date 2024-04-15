/*
�`������
new thread ���ާ@�D�����(form)�����

��ĳ�N�D��������檺�����W�ߥX�өI�scallback �_�h�i�঳�s�ا��������o�@������D����������εo��
*/

using Chevalier.iBox;
using Chevalier.iBox.Devices;
using Chevalier.iBox.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Chevalier.iBox.Runtime;

namespace Test_WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private delegate void AppendMessageCallback(string message);
        /// <summary>
        /// �s�W�T��
        /// </summary>
        /// <param name="message">�T��</param>
        /// <remarks>���P������]�i�H��</remarks>
        private void AppendMessage(string message)
        {
            try
            {
                if (this.InvokeRequired == true)
                {
                    AppendMessageCallback callback = new AppendMessageCallback(AppendMessage);
                    this.Invoke(callback, new object[] { message });
                }
                else
                {
                    string text = textBox_Message.Text;
                    if (text != "") { text = "\r\n" + text; }
                    textBox_Message.Text = message + text;

                    //textBox_Message.Text = message;
                }
            }
            catch { }
        }
