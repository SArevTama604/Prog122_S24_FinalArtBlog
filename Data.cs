using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog122_S24_FinalArtBlog
{
    public static class Data
    {
        private static readonly ObservableCollection<ArtPiece> _artPieces;

        static Data()
        {
            _artPieces = new ObservableCollection<ArtPiece>();

            // Example initialization
            string filePath = @"C:\Users\Salva\OneDrive\Attachments\coding assignments\Prog122_S24_FinalArtBlog\Images\GolfR.jpg";
            ArtPiece artPiece = new ArtPiece("Golf R", "Unknown Artist", "Sample body text.", filePath, Style.Realism, 2024);
            AddArtPiece(artPiece);
        }

        public static ObservableCollection<ArtPiece> ArtPieces => _artPieces;

        public static void AddArtPiece(ArtPiece artPiece)
        {
            _artPieces.Add(artPiece);
        }
    }
}