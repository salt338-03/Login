using Prism.Mvvm;
using System.Windows;
using Microsoft.Win32;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.IO;
using System.Collections.Generic;
using System;
using System.Printing;

namespace Login.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        Dictionary<string, string> IdPw = new Dictionary<string, string>();
        Dictionary<string, string> IDNum = new Dictionary<string, string>();

        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private string _selectedFilePath;
        public string SelectedFilePath
        {
            get => _selectedFilePath;
            set => SetProperty(ref _selectedFilePath, value);
        }
        private string _ID;
        public string ID
        {
            get => _ID;
            set => SetProperty(ref _ID, value);
        }
        private string _PW;
        public string PW
        {
            get => _PW;
            set => SetProperty(ref _PW, value);
        }
        public DelegateCommand Check { get; }
        public MainWindowViewModel()
        {
            Check = new DelegateCommand(CheckIDPW);
        }

        private void CheckIDPW()
        {
            try
            {
                if (IdPw.ContainsKey(ID))
                {
                    if (IdPw[ID] == PW)
                    {
                        MessageBox.Show($"로그인완료\r\n아이디 : {IdPw[ID]}\r\n전화번호 : {IDNum[ID]}");
                    }
                    else
                    {
                        MessageBox.Show("비밀번호가 틀렸습니다.");
                    }
                }
                else
                {
                    MessageBox.Show("존재하지 않는 ID입니다.");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("먼저 파일을 읽어주세요.");
            }
           
        }
        public void ProcessFile(string filePath)
        {
            // 파일 내용을 읽어 처리
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                // 데이터를 ','로 나누기
                var parts = line.Split(',');
                if (parts.Length == 3)
                {
                    string id = parts[0].Trim();   // 11
                    string pw = parts[1].Trim();   // 11
                    string phone = parts[2].Trim(); // 전화번호

                   
                    IdPw[id] = pw;   
                    IDNum[id] = phone; 
                }
                else
                {
                    Console.WriteLine($"잘못된 데이터 형식: {line}");
                }
            }
        }
    }
}
