using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicBookGallery.Models
{
    public class DrawingRevision
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string Status { get; set; }
        public string DisplayName
        {
            get
            {
                return ID + "-" + Name;
            }
        }
    }
}