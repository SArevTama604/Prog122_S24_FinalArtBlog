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

namespace Prog122_S24_FinalArtBlog
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Data.ArtPieces;
        }

        private void AddArtPieceButton_Click(object sender, RoutedEventArgs e)
        {
            AddArtPieceWindow addArtPieceWindow = new AddArtPieceWindow();
            addArtPieceWindow.ShowDialog();
        }

        private void ArtListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (artListView.SelectedItem is ArtPiece selectedArtPiece)
            {
                artImage.Source = selectedArtPiece.Art;
                artInfoRichTextBox.Document = selectedArtPiece.FormattedPost();
            }
        }
    }
}