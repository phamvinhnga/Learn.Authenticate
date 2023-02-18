namespace Learn.Authenticate.Entity.Model
{
    public class WebSettingModel
    {
        public AboutUsModel AboutUs { get; set; }
        public SliderModel Slider { get; set; }
        public CategoryFoodModel CategoryFood { get; set; }
        public FooterModel Footer { get; set; }
        public string CopyRight { get; set; }

        public class FooterModel
        {
            public string TextColor { get; set; }
            public string Logo { get; set; }
            public string BackgroundImage { get; set; }
            public ContactModel Contact { get; set; }
            public CertificateModel Certificate { get; set; }
            public SupportAndPolicyModel SupportAndPolicy { get; set; }
        }

        public class SliderModel
        {
            public List<SliderImageModel> Images { get; set; } = new List<SliderImageModel>();
        }

        public class SupportAndPolicyModel
        {
            public List<string> Contents { get; set; } = new List<string>();
        }
        
        public class CategoryFoodModel
        {
            public string TextColor { get; set; }
            public List<CategoryItemFoodModel> CategoryFoods { get; set; } 
        }

        public class CategoryItemFoodModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }
        }

        public class ContactModel
        {
            public string Facebook { get; set; }
            public string Instagram { get; set; }
            public string Email { get; set; }
            public string Hotline { get; set; }
            public string WorkingOffice { get; set; }
            public string RepresentativeStore { get; set; }
            public string AboutUs { get; set; }
        }

        public class CertificateModel
        {
            public string Content { get; set; }
        }

        public class AboutUsModel
        {
            public string Name { get; set; }
            public string Content { get; set; }
            public int PostId { get; set; }
            public string TextColor { get; set; }
            public string Logo { get; set; }
            public string Video { get; set; }
            public string BackgroundImage { get; set; }
        }

        public class SliderImageModel : FileModel
        {
        }
    }
}
