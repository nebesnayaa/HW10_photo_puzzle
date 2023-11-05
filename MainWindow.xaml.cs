using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HW10_photo_puzzle
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        Image selectedImage = null;

        private void PuzzlePiece_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                selectedImage = sender as Image;

                Image image = e.Source as Image;
                DataObject data = new DataObject(typeof(ImageSource), image.Source);

                DragDrop.DoDragDrop(image, data, DragDropEffects.All);
            }
        }

        private void puzzleGrid_Drop(object sender, DragEventArgs e)
        {
            Image droppedImage = (sender as Image);

            ImageSource droped = e.Data.GetData(typeof(ImageSource)) as ImageSource;

            if (droped != null)
            {
                selectedImage.Source = droppedImage.Source;
                droppedImage.Source = droped;
            }
        }
    }
}