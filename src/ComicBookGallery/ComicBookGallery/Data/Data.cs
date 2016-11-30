using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComicBookGallery.Models;

namespace ComicBookGallery.Data
{
    public static class Data
    {
        public static List<Drawing> Drawings { get; set; }

        public static List<DrawingRevision> DrawingRevisions { get; set; }
        public static List<Status> Statuses { get; set; }

        static Data()
        {
            InitData();
        }

        private static void InitData()
        {
            var drawingRevisions = new List<DrawingRevision>()
            {
                new DrawingRevision(91, "A", "1st Drawing First Revision", Status.StatusTypes.Released ,1 ,2016, 11, 27 ),
                new DrawingRevision(92, "B", "1st DrawingSecond Revision", Status.StatusTypes.Review,1, 2016, 11, 27 ),
                new DrawingRevision(93, "A", "2nd Drawing First Revision", Status.StatusTypes.Released, 2, 2016, 11, 27),
                new DrawingRevision(94, "B", "2nd Drawing Second Revision", Status.StatusTypes.Review, 2, 2016, 11, 27),
                new DrawingRevision(95, "A", "3rd Drawing First Revision", Status.StatusTypes.Released, 3, 2016, 11, 27),
                new DrawingRevision(96, "B", "3rd DrawingSecond Revision", Status.StatusTypes.Review, 3, 2016, 11, 27),
                new DrawingRevision(97, "A", "4th Drawing First Revision", Status.StatusTypes.Released,4,2016, 11, 27),
                new DrawingRevision(98, "B", "4th Drawing Second Revision", Status.StatusTypes.Review, 4,2016, 11, 27)
            };
            List<DrawingRevision> revisiontest = drawingRevisions.Where(dr => dr.DrawingId == 1).ToList();

            var drawings = new List<Drawing>()
            {
                new Drawing(1, "7676898921", "First Drawing", 2016, 11, 27, drawingRevisions.Where(dr => dr.DrawingId == 1).ToList()),
                new Drawing(2, "4343242", "Second Drawing", 2016, 10, 27, drawingRevisions.Where(dr => dr.DrawingId == 2).ToList()),
                new Drawing(3, "7545465-767", "Third Drawing", 2016, 9, 27, drawingRevisions.Where(dr => dr.DrawingId == 3).ToList()),
                new Drawing(4, "53435432-8586", "Fourth Drawing", 2016, 8, 27, drawingRevisions.Where(dr => dr.DrawingId == 4).ToList())
            };
            var statusList = new List<Status>()
            {
               new Status(Status.StatusTypes.IFA),
               new Status(Status.StatusTypes.IFC),
               new Status(Status.StatusTypes.IFI),
               new Status(Status.StatusTypes.Released),
               new Status(Status.StatusTypes.Review)
            };
            Drawings = drawings;
            DrawingRevisions = drawingRevisions;
            Statuses = statusList;
        }
    }
}