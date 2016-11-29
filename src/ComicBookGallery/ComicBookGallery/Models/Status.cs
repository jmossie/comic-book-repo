namespace ComicBookGallery.Models
{
    public class Status
    {
        public enum StatusTypes
        {
            Released = 1,
            Review = 2,
            IFC = 3,
            IFI = 4 ,
            IFA= 5
        }
        public Status(StatusTypes statusType, string name = null)
        {
            Id = (int)statusType;
            Name = name ?? statusType.ToString();
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}