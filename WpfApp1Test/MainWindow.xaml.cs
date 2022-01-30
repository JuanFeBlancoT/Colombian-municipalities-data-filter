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
		List<DataInfo> municipalities;

		public MainWindow()
		{
				InitializeComponent();

			municipalities = new List<DataInfo>();

			loadComboBox();
		}


		private void Button_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();

			bool? isContent = openFileDialog.ShowDialog();

			if (isContent == true)
			{
				string fileName = openFileDialog.FileName;
				

				using (StreamReader sr = new StreamReader(openFileDialog.FileName))
				{
					sr.ReadLine();
					while (!sr.EndOfStream)
					{
						string x = sr.ReadLine();
						string[] xInfo = x.Split(',');
						try
						{
							DataInfo oneData = new DataInfo(xInfo[0], xInfo[1], xInfo[2], xInfo[3], xInfo[4]);
							municipalities.Add(oneData);
							MuniDataGrid.Items.Add(oneData);
						}
						catch (Exception)
						{
						}

					}
					Console.WriteLine("La lista tiene: " + municipalities.Count());
				}
			}
		}

		public int[] GetStatistics()
		{

			DataInfo[] arrayInfo = municipalities.ToArray();
			int isle = 0, municipality = 0, nonNunicipality = 0;
			for (int i = 0; i < arrayInfo.Length; i++)
			{
				string type = municipalities[i].typeX;
				if (type.Equals("Isla"))
				{
					isle++;
				}
				else if (type.Equals("Municipio"))
				{
					municipality++;
				}
				else
				{
					nonNunicipality++;
				}
			}
			int[] results = new int[3];
		
			results[0] = municipality;
			results[1] = isle;
			results[2] = nonNunicipality;

			return results;
		}

		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
				//Code for filtering according to the initial of the department, for 
				//full implementation, pass the initial as the argument in the predicate of FindAll

				DataInfo[] arrayInfo = municipalities.ToArray();

				//Get the current selected item from combobox as a string
				string letterToFilter = FilterSelector.SelectionBoxItem.ToString();

				//filter
				DataInfo[] filtered = Array.FindAll(arrayInfo, x => x.IsInitial(letterToFilter));

						MuniDataGrid.Items.Clear();

						for (int i = 0; i < filtered.Length; i++) {
								Console.WriteLine(i);
								MuniDataGrid.Items.Add(filtered[i]);
						}
			}

				private void loadComboBox()
		{
			//Add all letters to list with ASCII
			System.Collections.ObjectModel.ObservableCollection<Char> listInitials = new System.Collections.ObjectModel.ObservableCollection<Char>();
			//listInitials.Add(' ');
			for (int i = 65; i < 91; i++)
			{
				listInitials.Add((char)i);
			}

			FilterSelector.ItemsSource = listInitials;

		}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
			Window1 objectSecond = new Window1();
			objectSecond.Show();	
        }
    }

}



