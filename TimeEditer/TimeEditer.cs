using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimeEditerDemo
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:TimeEditer"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:TimeEditer;assembly=TimeEditer"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误: 
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:TimeEditer/>
    ///
    /// </summary>
    public class TimeEditer : Control
    {
        static TimeEditer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimeEditer), new FrameworkPropertyMetadata(typeof(TimeEditer)));
        }

        private TextBox currentTextBox;
        private Button btnUp;
        private Button btnDown;
        private TextBox txt1;
        private TextBox txt2;
        private TextBox txt3;
        private TextBox txt4;

        public TimeEditer()
        {
            var newTime = DateTime.Now.AddMinutes(5);
            Hour = newTime.Hour;
            Minute = newTime.Minute;
            Second = newTime.Second;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            btnUp = Template.FindName("PART_UP", this) as Button;
            btnDown = Template.FindName("PART_DOWN", this) as Button;
            txt1 = Template.FindName("PART_TXTHOUR", this) as TextBox;
            txt2 = Template.FindName("PART_TXTMINUTE", this) as TextBox;
            txt3 = Template.FindName("PART_TXTSECOND", this) as TextBox;
            txt4 = Template.FindName("PART_TXT4", this) as TextBox;


            txt1.GotFocus += TextBox_GotFocus;
            txt2.GotFocus += TextBox_GotFocus;
            txt3.GotFocus += TextBox_GotFocus;
            txt1.LostFocus += TextBox_LostFocus;
            txt2.LostFocus += TextBox_LostFocus;
            txt3.LostFocus += TextBox_LostFocus;
            txt1.KeyDown += Txt1_KeyDown;
            txt2.KeyDown += Txt1_KeyDown;
            txt3.KeyDown += Txt1_KeyDown;

            txt4.GotFocus += TextBox2_GotFocus;
            txt4.LostFocus += TextBox2_LostFocus;

            this.GotFocus += UserControl_GotFocus;
            this.LostFocus += UserControl_LostFocus;

            this.Repeater(btnUp, (t, num, reset) =>
            {
                if (reset && t.Interval == 500)
                    t.Interval = 50;
                Dispatcher.Invoke(new Action(() =>
                {
                    if (currentTextBox.Name == "PART_TXTHOUR")
                    {
                        int.TryParse(currentTextBox.Text, out int numResult);
                        numResult += num;
                        if (numResult >= 24)
                            numResult = 0;
                        if (numResult < 0)
                            numResult = 23;
                        currentTextBox.Text = numResult.ToString("00");
                    }
                    else if (currentTextBox.Name == "PART_TXTMINUTE")
                    {
                        int.TryParse(currentTextBox.Text, out int numResult);
                        numResult += num;
                        if (numResult >= 60)
                            numResult = 0;
                        if (numResult < 0)
                            numResult = 59;
                        currentTextBox.Text = numResult.ToString("00");
                    }
                    else if (currentTextBox.Name == "PART_TXTSECOND")
                    {
                        int.TryParse(currentTextBox.Text, out int numResult);
                        numResult += num;
                        if (numResult >= 60)
                            numResult = 0;
                        if (numResult < 0)
                            numResult = 59;
                        currentTextBox.Text = numResult.ToString("00");
                    }
                }));

            }, 1);
            this.Repeater(btnDown, (t, num, reset) =>
            {
                if (reset && t.Interval == 500)
                    t.Interval = 50;
                Dispatcher.Invoke(new Action(() =>
                {
                    if (currentTextBox.Name == "PART_TXTHOUR")
                    {
                        int.TryParse(currentTextBox.Text, out int numResult);
                        numResult += num;
                        if (numResult >= 24)
                            numResult = 0;
                        if (numResult < 0)
                            numResult = 23;
                        currentTextBox.Text = numResult.ToString("00");
                    }
                    else if (currentTextBox.Name == "PART_TXTMINUTE")
                    {
                        int.TryParse(currentTextBox.Text, out int numResult);
                        numResult += num;
                        if (numResult >= 60)
                            numResult = 0;
                        if (numResult < 0)
                            numResult = 59;
                        currentTextBox.Text = numResult.ToString("00");
                    }
                    else if (currentTextBox.Name == "PART_TXTSECOND")
                    {
                        int.TryParse(currentTextBox.Text, out int numResult);
                        numResult += num;
                        if (numResult >= 60)
                            numResult = 0;
                        if (numResult < 0)
                            numResult = 59;
                        currentTextBox.Text = numResult.ToString("00");
                    }
                }));

            }, -1);
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            textBox.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0078d7"));
            textBox.Foreground = new SolidColorBrush(Colors.White);
            currentTextBox = textBox;

        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            textBox.Background = new SolidColorBrush(Colors.Transparent);
            textBox.Foreground = new SolidColorBrush(Colors.Black);
            int.TryParse(currentTextBox.Text, out int numResult);
            currentTextBox.Text = numResult.ToString("00");
        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            this.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 234, 234, 234));
            NumIncreaseVisible = Visibility.Collapsed;
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            this.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 120, 215));
            NumIncreaseVisible = Visibility.Visible;
        }

        private void TextBox2_GotFocus(object sender, RoutedEventArgs e)
        {
            txt3.Focus();
        }

        private void TextBox2_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        public void Repeater(Button btn, Action<Timer, int, bool> callBack, int num, int interval = 500)
        {
            var timer = new Timer { Interval = interval };
            timer.Elapsed += (sender, e) =>
            {
                callBack?.Invoke(timer, num, true);
            };
            btn.PreviewMouseLeftButtonDown += (sender, e) =>
            {
                callBack?.Invoke(timer, num, false);
                timer.Start();
            };
            btn.PreviewMouseLeftButtonUp += (sender, e) =>
            {
                timer.Interval = 500;
                timer.Stop();
            };
        }

        private void Txt1_KeyDown(object sender, KeyEventArgs e)
        {
            int.TryParse(currentTextBox.Text, out int numResult);

            if ((int)e.Key >= 34 && (int)e.Key <= 43)
            {

                if (currentTextBox.Text.Length == 1)
                {
                    int.TryParse(currentTextBox.Text + ((int)e.Key - 34).ToString(), out int preNumResult);
                    if (currentTextBox.Name == "PART_TXTHOUR")
                    {
                        if (preNumResult >= 24)
                        {
                            return;
                        }
                    }
                    else if (currentTextBox.Name == "PART_TXTMINUTE")
                    {
                        if (preNumResult >= 60)
                        {
                            return;
                        }
                    }
                    else if (currentTextBox.Name == "PART_TXTSECOND")
                    {
                        if (preNumResult >= 60)
                        {
                            return;
                        }
                    }

                    currentTextBox.Text += ((int)e.Key - 34).ToString();
                }
                else
                {
                    currentTextBox.Text = ((int)e.Key - 34).ToString();
                }
            }

            if ((int)e.Key >= 74 && (int)e.Key <= 83)
            {

                if (currentTextBox.Text.Length == 1)
                {
                    int.TryParse(currentTextBox.Text + ((int)e.Key - 74).ToString(), out int preNumResult);
                    if (currentTextBox.Name == "PART_TXTHOUR")
                    {
                        if (preNumResult >= 24)
                        {
                            return;
                        }
                    }
                    else if (currentTextBox.Name == "PART_TXTMINUTE")
                    {
                        if (preNumResult >= 60)
                        {
                            return;
                        }
                    }
                    else if (currentTextBox.Name == "PART_TXTSECOND")
                    {
                        if (preNumResult >= 60)
                        {
                            return;
                        }
                    }
                    currentTextBox.Text += ((int)e.Key - 74).ToString();
                }
                else
                {
                    currentTextBox.Text = ((int)e.Key - 74).ToString();
                }
            }

        }



        public int Hour
        {
            get { return (int)GetValue(HourProperty); }
            set { SetValue(HourProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Hour.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HourProperty =
            DependencyProperty.Register("Hour", typeof(int), typeof(TimeEditer), new PropertyMetadata(DateTime.Now.Hour));


        public int Minute
        {
            get { return (int)GetValue(MinuteProperty); }
            set { SetValue(MinuteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Minute.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinuteProperty =
            DependencyProperty.Register("Minute", typeof(int), typeof(TimeEditer), new PropertyMetadata(DateTime.Now.Minute));


        public int Second
        {
            get { return (int)GetValue(SecondProperty); }
            set { SetValue(SecondProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Second.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SecondProperty =
            DependencyProperty.Register("Second", typeof(int), typeof(TimeEditer), new PropertyMetadata(DateTime.Now.Second));



        public Visibility NumIncreaseVisible
        {
            get { return (Visibility)GetValue(NumIncreaseVisibleProperty); }
            set { SetValue(NumIncreaseVisibleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NumIncreaseVisible.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumIncreaseVisibleProperty =
            DependencyProperty.Register("NumIncreaseVisible", typeof(Visibility), typeof(TimeEditer), new PropertyMetadata(Visibility.Collapsed));


    }
}
