using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicBookGallery.Models
{
    public class Drawing
    {
        public int Id { get; set; }
        public string DrawingNumber { get; set; }
        public string DrawingName { get; set; }
        public DrawingRevision[] DrawingRevisions { get; set; } 
        public string DisplayName
        {
            get
            {
                return DrawingNumber + "-" + DrawingName;
            }
        }
    }
    }
