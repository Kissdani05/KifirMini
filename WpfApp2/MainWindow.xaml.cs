using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace WpfApp2
{
    
    public partial class MainWindow : Window
    {
        ObservableCollection<Felvetelizok> lista = new ObservableCollection<Felvetelizok>();



        public MainWindow()
        {
            InitializeComponent();
            using (StreamReader sr = new StreamReader("felvetelizok.csv"))
            {
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    Felvetelizok sor1 = new Felvetelizok(sor);
                    lista.Add(sor1);
                }
            }
            myDataGrid.ItemsSource = lista;







        }


        private void NewStudentButton_Click(object sender, RoutedEventArgs e)
        {
            Felvetelizok ujdiak = new Felvetelizok();

            UjDiak hozzaadott = new UjDiak(ujdiak, true);
            hozzaadott.ShowDialog();
            lista.Add(ujdiak);

        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.SelectedItems.Count > 0)
            {
                var selectedItems = myDataGrid.SelectedItems.Cast<Felvetelizok>().ToList();
                foreach (var selectedItem in selectedItems)
                {
                    lista.Remove(selectedItem);
                }
            }
        }

        private void ExportToCsv_Click(object sender, RoutedEventArgs e)
        {
            var dataToExport = myDataGrid.ItemsSource as ObservableCollection<Felvetelizok>;
            if (dataToExport == null || !dataToExport.Any())
            {
                MessageBox.Show("No data to export.");
                return;
            }

            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "CSV file (*.csv)|*.csv|JSON file (*.json)|*.json",
                DefaultExt = "csv"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                string fileExtension = System.IO.Path.GetExtension(filePath).ToLower();

                // Check if file already exists
                if (File.Exists(filePath))
                {
                    MessageBoxResult overwriteConfirmation = MessageBox.Show("The file already exists. Do you want to overwrite it?", "Confirm Overwrite", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (overwriteConfirmation != MessageBoxResult.Yes)
                    {
                        return; // Do not overwrite
                    }
                }

                try
                {
                    switch (fileExtension)
                    {
                        case ".csv":
                            ExportToCsv(filePath, dataToExport);
                            break;

                        case ".json":
                            ExportToJson(filePath, dataToExport);
                            break;

                        default:
                            MessageBox.Show("Selected file type is not supported for export.");
                            return;
                    }

                    MessageBox.Show("Export successful.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error during export: {ex.Message}");
                }
            }
        }

        private void ExportToCsv(string filePath, ObservableCollection<Felvetelizok> data)
        {
            StringBuilder csvContent = new StringBuilder();
            var headers = myDataGrid.Columns.Select(column => column.Header.ToString());
            csvContent.AppendLine(string.Join(",", headers));

            foreach (Felvetelizok item in data)
            {
                var values = item.GetType().GetProperties().Select(pi => (pi.GetValue(item, null) ?? "").ToString());
                var line = string.Join(",", values.Select(value => $"\"{value.Replace("\"", "\"\"")}\"")); // Handle commas and quotes in values
                csvContent.AppendLine(line);
            }

            File.WriteAllText(filePath, csvContent.ToString());
        }

        private void ExportToJson(string filePath, ObservableCollection<Felvetelizok> data)
        {
            string jsonContent = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, jsonContent);
        }








        private void ImportFromCsv_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|JSON files (*.json)|*.json|All files (*.*)|*.*",
                Title = "Válassz egy fájlt, amit importálni szeretnél."
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    string fileExtension = System.IO.Path.GetExtension(filePath).ToLower();

                    // Determine if overwrite is needed
                    bool overwrite = lista.Count == 0; // overwrite if lista is empty

                    // Ask the user if the list is not empty
                    if (!overwrite)
                    {
                        MessageBoxResult result = MessageBox.Show("Szeretnéd felülírni a fájlt? Ha hozzá szeretnéd adni akkor nyomj a nemre", "Import", MessageBoxButton.YesNoCancel);
                        if (result == MessageBoxResult.Cancel)
                        {
                            return;
                        }
                        overwrite = result == MessageBoxResult.Yes;
                    }

                    if (overwrite)
                    {
                        lista.Clear();
                    }

                    switch (fileExtension)
                    {
                        case ".csv":
                            using (StreamReader sr = new StreamReader(filePath))
                            {
                                while (!sr.EndOfStream)
                                {
                                    string line = sr.ReadLine();
                                    Felvetelizok item = new Felvetelizok(line); // Assuming constructor parses CSV line
                                    lista.Add(item);
                                }
                            }
                            break;

                        case ".json":
                            string jsonContent = File.ReadAllText(filePath);
                            List<Felvetelizok> items = JsonConvert.DeserializeObject<List<Felvetelizok>>(jsonContent); // Deserialize JSON
                            foreach (var item in items)
                            {
                                lista.Add(item);
                            }
                            break;

                        default:
                            MessageBox.Show("Nem támogatott fájltípus!");
                            return;
                    }

                    myDataGrid.ItemsSource = lista;
                    MessageBox.Show("Sikeres importálás.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hiba! {ex.Message}");
                }
            }
        }

        private void ModositasButton_Click(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.SelectedItem is Felvetelizok selectedFelvetelizo)
            {
                // Assuming 'false' means that the dialog is in edit mode and 'true' means create mode.
                UjDiak ujDiakWindow = new UjDiak(selectedFelvetelizo, false);
                
                ujDiakWindow.ShowDialog();
                // Refresh the data grid or update the selected row based on changes
            }
            else
            {
                MessageBox.Show("Select a row first");
            }
        }

    }
}