using System;
using System.Collections.Generic;
using System.Text;

namespace Dispaly_Find_Sort
{
    internal class Track
    {
        public int TrackId { get; set; }
        public string TrackName { get; set; }

        static int idIdentity = 1;


        public Track()
        {
            TrackId = idIdentity++;
            TrackName = string.Empty;
        }

        public Track(string trackName)
        {
            TrackId = idIdentity++;
            TrackName = trackName;
        }

        public override string ToString()
        {
            return $"Track: [Id: {TrackId}, Name: {TrackName}]";
        }
    }
}
