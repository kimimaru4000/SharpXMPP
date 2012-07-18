﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SharpXMPP.XMPP;

namespace SharpXMPP.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private XmppComponentConnection client;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            client = new XmppComponentConnection(new JID(textBox1.Text), passwordBox1.Password) { InitialPresence = true};
            client.Element += (o, args) => Dispatcher.Invoke((Action)(() => listBox1.Items.Add(args.Stanza.ToString())));
            ThreadPool.QueueUserWorkItem((o) => client.Connect());
        }
    }
}
