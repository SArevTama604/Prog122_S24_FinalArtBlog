using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

namespace Prog122_S24_FinalArtBlog
{
    public enum Style
    {
        Abstract,
        Realism,
        Impressionism,
        Surrealism
    }

    public class ArtPiece
    {
        private AddArtPieceWindow.Style artStyle;
        private int year;

        public string Name { get; set; }
        public string Artist { get; set; }
        public string Body { get; set; }
        public string FilePath { get; set; }
        public BitmapImage Art { get; set; }
        public Style ArtStyle { get; set; }
        public int Date { get; set; }

        public ArtPiece(string name, string artist, string body, string filePath, Style artStyle, int date)
        {
            Name = name;
            Artist = artist;
            Body = body;
            FilePath = filePath;
            ArtStyle = artStyle;
            Date = date;
            Art = GenerateBitmap(filePath);
        }

        public ArtPiece(string name, string artist, string body, string filePath, AddArtPieceWindow.Style artStyle, int year)
        {
            Name = name;
            Artist = artist;
            Body = body;
            FilePath = filePath;
            this.artStyle = artStyle;
            this.year = year;
        }

        private BitmapImage GenerateBitmap(string filePath)
        {
            return new BitmapImage(new Uri(filePath));
        }

        public FlowDocument FormattedPost()
        {
            FlowDocument doc = new FlowDocument();
            doc.Blocks.Add(Header_Formatted());
            doc.Blocks.Add(Date_Formatted());
            doc.Blocks.Add(Artist_Formatted());
            doc.Blocks.Add(Body_Formatted());
            return doc;
        }

        private Paragraph Date_Formatted()
        {
            return new Paragraph(new Run(Date.ToString())) { FontSize = 12, FontFamily = new System.Windows.Media.FontFamily("Cascadia Code") };
        }

        private Paragraph Header_Formatted()
        {
            return new Paragraph(new Run(Name)) { FontSize = 24, FontFamily = new System.Windows.Media.FontFamily("Cascadia Code") };
        }

        private Paragraph Artist_Formatted()
        {
            return new Paragraph(new Run(Artist)) { FontSize = 18, FontFamily = new System.Windows.Media.FontFamily("Cascadia Code") };
        }

        private Paragraph Body_Formatted()
        {
            return new Paragraph(new Run(Body)) { FontSize = 14, FontFamily = new System.Windows.Media.FontFamily("Cascadia Code") };
        }
    }
}