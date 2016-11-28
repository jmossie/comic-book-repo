using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ComicBookGallery.Models;

namespace ComicBookGallery.Models
{
    public class Drawing
    {
        public Drawing()
        {

        }
        public Drawing(int id, string drawingNumber, string drawingName, int year, int month, int day, List<DrawingRevision> revisions, string notes = null)
        {
            Id = id;
            DrawingNumber = drawingNumber;
            DrawingName = drawingName;
            CreateDate = new DateTime(year, month, day);
            Revisions = revisions;
            Notes = notes;
            
        }
        public int Id { get; set; }
        [Display(Name = "Drawing Number")]
        [Required]
        public string DrawingNumber { get; set; }
        [Display(Name = "Drawing Name")]
        public string DrawingName { get; set; }
        [Display(Name = "Creation Date")]
        public DateTime CreateDate { get; set; }
        public List<DrawingRevision> Revisions { get; set; }


        [MaxLength(200, ErrorMessage = "The Notes field cannot be longer than 200 characters.")]
        public string Notes { get; set; }     
        public string DisplayName
        {
            get
            {
                return DrawingNumber + "-" + DrawingName;
            }
        }
    }
    }
