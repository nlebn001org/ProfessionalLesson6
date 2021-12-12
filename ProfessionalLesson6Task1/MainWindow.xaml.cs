using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProfessionalLesson6Task1
{

    //    Создайте программу-рефлектор, которая позволит получить информацию о сборке и входящих
    //в ее состав типах.Для основы можно использовать программу-рефлектор из урока.

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Assembly assembly = null;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "DLL files(*.dll)|*.dll";
            string fullPath;
            if (openFileDialog.ShowDialog(this) == true)
            {
                fullPath = openFileDialog.FileName;
                try
                {
                    assembly = Assembly.LoadFile(fullPath);
                    txtEditor.Text += "Solution with a fullpath: " + fullPath + "  was downloaded" + Environment.NewLine + Environment.NewLine;
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                txtEditor.Text += "All types in assembly fullname: " + assembly.FullName + Environment.NewLine + Environment.NewLine;

                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    txtEditor.Text += "Тип:  " + type + Environment.NewLine;
                    var methods = type.GetMethods();
                    if (methods != null)
                    {
                        foreach (var method in methods)
                        {
                            string methStr = "Метод:" + method.Name + "\n";
                            var methodBody = method.GetMethodBody();
                            if (methodBody != null)
                            {
                                var byteArray = methodBody.GetILAsByteArray();

                                foreach (var b in byteArray)
                                {
                                    methStr += b + ":";
                                }
                            }
                            txtEditor.Text += methStr + Environment.NewLine;
                        }
                    }
                }
            }
        }
    }
}
