using System.Collections.Generic;

namespace SCommerce.Main.ViewModels
{
    public class ProductDetailsPageViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Rating { get; set; }
        public List<string> Images { get; set; }
        public string SelectedImage { get; set; }

        public ProductDetailsPageViewModel()
        {
            Title = "Great Product";
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse magna turpis, egestas sed leo ut, blandit porttitor ligula. Vivamus a sodales dui.";
            Price = 99.99;
            Rating = 4;
            Images = new List<string>
            {
                "ms-appx:///Assets/Images/shirt1.jpg",
                "ms-appx:///Assets/Images/shirt2.jpg",
                "ms-appx:///Assets/Images/shirt3.jpg",
            };
            SelectedImage = Images[0];
        }
    }
}
