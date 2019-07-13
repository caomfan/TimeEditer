using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TimeEditerDemo
{
    public class MainVm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var properyName = (propertyExpression.Body as MemberExpression).Member.Name;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properyName));
        }
        private static MainVm instance;
        public static MainVm Instance
        {
            get
            {
                if (instance == null) instance = new MainVm();
                return instance;
            }
        }
        private MainVm()
        {
            Hour = 1;
            Minute = 2;
            Seccond = 3;
        }

        private int _Hour;
        public int Hour
        {
            get { return _Hour; }
            set { _Hour = value; OnPropertyChanged(() => Hour); }
        }

        private int _Minute;
        public int Minute
        {
            get { return _Minute; }
            set { _Minute = value; OnPropertyChanged(() => Minute); }
        }

        private int _Seccond;
        public int Seccond
        {
            get { return _Seccond; }
            set { _Seccond = value; OnPropertyChanged(() => Seccond); }
        }
    }
}
