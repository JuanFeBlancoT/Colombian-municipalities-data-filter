using System;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using System.Collections;

namespace WpfApp1Test
{
		/// <summary>
		/// Lógica de interacción para MainWindow.xaml
		/// </summary>
		public partial class MainWindow : Window
		{
				public MainWindow()
				{
						InitializeComponent();
				}

				private void Button_Click(object sender, RoutedEventArgs e)
				{
						OpenFileDialog openFileDialog = new OpenFileDialog();

						bool? isContent = openFileDialog.ShowDialog();

						if (isContent == true){
								string fileName = openFileDialog.FileName;

								ArrayList datasX = new ArrayList();

								DataGrid dataGrid = new DataGrid();
								//dataGrid.Columns.Add(new DataGridTextColumn());

								using (StreamReader sr = new StreamReader(openFileDialog.FileName)) {
										while (!sr.EndOfStream) {
												string x = sr.ReadLine();
												string[] xInfo = x.Split(',');
												DataInfo oneData = new DataInfo(xInfo[0], xInfo[1], xInfo[2], xInfo[3], xInfo[4]);
												datasX.Add(oneData);
										}
								}

							
						}
				}
		}
}
