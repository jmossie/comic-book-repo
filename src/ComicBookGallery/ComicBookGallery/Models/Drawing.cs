using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComicBookGallery.Models
{
    public class Drawing
    {
        public Drawing()
        {

        }
        public Drawing(int id, string drawingNumber, string drawingName)
        {
            Id = id;
            DrawingNumber = drawingNumber;
            DrawingName = drawingName;
        }
        public int Id { get; set; }
        public string DrawingNumber { get; set; }
        public string DrawingName { get; set; }


        public string DisplayName
        {
            get
            {
                return DrawingNumber + "-" + DrawingName;
            }
        }
    }
    }
