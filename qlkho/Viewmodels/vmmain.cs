using qlkho.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace qlkho.Viewmodels
{
    public class vmmain : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public vmmain() {
            cmdNewuser = new relayCommand(excuteNew);
            cmdEdit = new relayCommand(executeEdit);
        }

       
        private void OnPropertyChanged(string name)
        {
              PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(name));
        }

        private ICommand _command;
        public ICommand cmdNewuser
        {
            get { return _command; }
            set { _command = value;
            OnPropertyChanged(nameof(cmdNewuser));}
        }

        private void excuteNew(object obj)
        {
            if(obj != null) {
                //var o=obj as modelUser;
                MessageBox.Show(obj.ToString());
            }
        }

        private ICommand _cmdEdit;
        public ICommand cmdEdit
        {
            get { return _cmdEdit; }
            set { _cmdEdit = value; OnPropertyChanged(nameof(cmdEdit)); }
        }
        private void executeEdit(object obj)
        {
            caculaDelegate cal;
            cal = add2num;
            var resultAdd = cal.Invoke(3, 9);
            cal = subtrack2num;
            var resultSub = cal(3, 9);

            MessageBox.Show($"cộng={resultAdd} ; trừ = {resultSub}");

            executeback(3, 9, addNmvoid);
            executeback(10, 4, subNumvoid);
            //multithread
            Thread thr1 = new Thread(funTime);
            Thread thr2=new Thread(funTime);
            thr1.Start();
            thr2.Start();
            thr1.Join();
            thr2.Join();
            MessageBox.Show($"Gia tri count chung: {countChung}");

            Thread thr3 = new Thread(new ParameterizedThreadStart(ghichung));
            Thread thr4 = new Thread(new ParameterizedThreadStart(ghichung));
            thr3.Start("T");
            thr4.Start("S");
            thr3.Join();
            thr4.Join();

            MessageBox.Show(stchung);
            // prossecc
            Process process = new Process();
            //gan tien trinh xu ly
            process.StartInfo.FileName = "notepad.exe";
            // gán giá trị xu lý
            process.StartInfo.Arguments = "txt.txt";
            //khởi động tien trinh
            process.Start();
            //chờ tiến trình xử lý xong
            process.WaitForExit();
            //lấy kết quả cảu tien trình
            var kq = process.ExitCode;
            MessageBox.Show($"result process: {kq}");
            // binding
            username = obj.ToString();
        }
        // test delegate
        //delagate là kieu du lieu đăc biệt cho phép thể hiện của nó tham chiếu đến 1 phương thức cùng kiểu dữ liệu trả về và cùng các tham số truền
        delegate int caculaDelegate(int a, int b);
        private int add2num(int a, int b)
        {
            return a + b;
        }
        private int subtrack2num(int a, int b)
        {
            return a - b;
        }
        //
        delegate void calbackDelegate(int A, int B);
        private void executeback(int a, int b, calbackDelegate calback) {
           calback.Invoke(a, b);
        }
        private void addNmvoid(int a, int b)
        {
            var s = a + b;
        }
        private void subNumvoid(int a, int b)
        {
            var s = a - b;
        }
        //MULTITHREAD

        private int countChung = 0;
        private object objLock=new object();
        private string stchung = "";
        private void funTime()
        {  
            for (int i = 0; i < 100; i++)
            {
                lock (objLock)   // đảm bảo tại 1 thời điểm chỉ có 1 luồng thay đổi giá trị của count
                {
                    Thread.Sleep(1);
                    countChung++;
                }
            } 
        }
        private void ghichung(object thNum)
        {
            for(int i=0; i < 10; i++)
            {
                lock(objLock)
                {
                    Thread.Sleep(10);
                    stchung += thNum.ToString() + ",";
                }
            }
        }

        private string _username;
        public string username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(username));
            }
        }
    }
}
