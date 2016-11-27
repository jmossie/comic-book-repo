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

        static Data()
        {
            InitData();
        }

        private static void InitData()
        {
            var drawingRevisions = new List<DrawingRevision>()
            {
                new DrawingRevision("A", "1st Drawing First Revision", DrawingRevision.ReleaseStatus.Released, 1 ),
                new DrawingRevision("B", "1st DrawingSecond Revision", DrawingRevision.ReleaseStatus.Review, 1 ),
                new DrawingRevision("A", "2nd Drawing First Revision", DrawingRevision.ReleaseStatus.Released, 2 ),
                new DrawingRevision("B", "2nd Drawing Second Revision", DrawingRevision.ReleaseStatus.Review, 2 ),
                new DrawingRevision("A", "3rd Drawing First Revision", DrawingRevision.ReleaseStatus.Released, 3 ),
                new DrawingRevision("B", "3rd DrawingSecond Revision", DrawingRevision.ReleaseStatus.Review, 3 ),
                new DrawingRevision("A", "4th Drawing First Revision", DrawingRevision.ReleaseStatus.Released, 4 ),
                new DrawingRevision("B", "4th Drawing Second Revision", DrawingRevision.ReleaseStatus.Review, 4 )
            };
            var drawings = new List<Drawing>()
            {
                new Drawing(1, "7676898921", "First Drawing"),
                new Drawing(1, "7676898921", "First Drawing"),
                new Drawing(1, "7676898921", "First Drawing"),
                new Drawing(1, "7676898921", "First Drawing")
            };
            Drawings = drawings;
            DrawingRevisions = drawingRevisions;
        }
    }
}