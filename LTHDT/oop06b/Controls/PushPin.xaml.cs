﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Oop06b.Controls
{
    /// <summary>
    /// Interaction logic for PushPin.xaml
    /// </summary>
    public partial class PushPin : UserControl
    {
        // Using a DependencyProperty as the backing store for IsOpen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(PushPin), new PropertyMetadata(false, OnIsOpenChanged));

        private static void OnIsOpenChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            PushPin pin = sender as PushPin;
            pin.IsOpen = (bool)e.NewValue;
        }

        public PushPin()
        {
            InitializeComponent();
        }

        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set
            {
                SetValue(IsOpenProperty, value);
                if (value)
                    Show();
            }
        }

        public void Show()
        {
            var storyboard = this.FindResource("ShowPushPin") as Storyboard;
            storyboard.Begin();
        }
    }
}