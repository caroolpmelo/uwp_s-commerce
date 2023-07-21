using System.Collections.Generic;
using System.ComponentModel;

namespace SCommerce.Main.ViewModels
{
    public class ProductDetailsPageViewModel : INotifyPropertyChanged
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Rating { get; set; }

        public List<string> Images { get; set; }

        private string selectedImage;
        public string SelectedImage
        {
            get { return selectedImage; }
            set
            {
                if (selectedImage != value)
                {
                    selectedImage = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedImage"));
                }
            }
        }

        public ProductDetailsPageViewModel()
        {
            Title = "Great Product";
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse magna turpis, egestas sed leo ut, blandit porttitor ligula. Vivamus a sodales dui.";
            Price = 99.99452;
            Rating = 4;
            Images = new List<string>
            {
                "ms-appx:///Assets/Images/shirt1.jpg",
                "ms-appx:///Assets/Images/shirt2.jpg",
                "ms-appx:///Assets/Images/shirt3.jpg",
            };
            SelectedImage = Images[0];
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
