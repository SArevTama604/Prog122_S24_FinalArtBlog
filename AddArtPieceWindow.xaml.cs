using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace Prog122_S24_FinalArtBlog
{
    public partial class AddArtPieceWindow : Window
    {
        private string _filePath;

        public enum Style
        {
            Abstract,
            Realism,
            Impressionism,
            Surrealism
        }

        public AddArtPieceWindow()
        {
            InitializeComponent();
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.png)|*.jpg;*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                _filePath = openFileDialog.FileName;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(_filePath);
                bitmap.EndInit();

                selectedImage.Source = bitmap;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            string artist = artistTextBox.Text;
            string body = new TextRange(bodyRichTextBox.Document.ContentStart, bodyRichTextBox.Document.ContentEnd).Text;

            int year = 0;
            if (yearComboBox.SelectedItem != null && int.TryParse((yearComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString(), out year))
            {
                Style artStyle = Style.Abstract; 
                if (realismRadioButton.IsChecked == true) artStyle = Style.Realism;
                else if (impressionismRadioButton.IsChecked == true) artStyle = Style.Impressionism;
                else if (surrealismRadioButton.IsChecked == true) artStyle = Style.Surrealism;

                ArtPiece newArtPiece = new ArtPiece(name, artist, body, _filePath, artStyle, year);
                Data.AddArtPiece(newArtPiece);

                ClearFields();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a valid year.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearFields()
        {
            nameTextBox.Text = string.Empty;
            artistTextBox.Text = string.Empty;
            bodyRichTextBox.Document.Blocks.Clear();
            yearComboBox.SelectedIndex = -1;
            abstractRadioButton.IsChecked = true;
            selectedImage.Source = null; 
        }
    }
}