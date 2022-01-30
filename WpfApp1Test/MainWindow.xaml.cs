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

						loadComboBox();
				}

				private void Button_Click(object sender, RoutedEventArgs e)
				{
						OpenFileDialog openFileDialog = new OpenFileDialog();

						bool? isContent = openFileDialog.ShowDialog();

						if (isContent == true){
								string fileName = openFileDialog.FileName;

								List<DataInfo> datasX = new List<DataInfo>();

								using (StreamReader sr = new StreamReader(openFileDialog.FileName)) {
									sr.ReadLine();
									while (!sr.EndOfStream)
									{
										string x = sr.ReadLine();
										string[] xInfo = x.Split(',');
									try
									{
										DataInfo oneData = new DataInfo(xInfo[0], xInfo[1], xInfo[2], xInfo[3], xInfo[4]);
										datasX.Add(oneData);
                    MuniDataGrid.Items.Add(oneData);
									}
									catch (Exception ex) { 
									}
										
									}
								}

								//Code for filtering according to the initial of the department, for 
								//full implementation, pass the initial as the argument in the predicate of FindAll

								DataInfo[] arrayInfo = datasX.ToArray();

								DataInfo[] filtered = Array.FindAll(arrayInfo, x => x.IsInitial("V"));



						}
				}

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
						
        }

				private void loadComboBox() {
						//Add all letters to list with ASCII
						System.Collections.ObjectModel.ObservableCollection<Char> listInitials = new System.Collections.ObjectModel.ObservableCollection<Char>();
						listInitials.Add(' ');
						for (int i = 65; i < 91; i++) {
								listInitials.Add((char)i);
						}

						FilterSelector.ItemsSource=listInitials;

				}
    }
}
