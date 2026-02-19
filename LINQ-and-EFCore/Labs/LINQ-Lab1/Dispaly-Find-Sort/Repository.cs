using System;
using System.Collections.Generic;
using System.Text;

namespace Dispaly_Find_Sort
{
    internal static class Repository
    {
        public static List<Student> GetStudents()
        {
            return new List<Student>()
            {
                new Student("Mohanad", "Khaled", 24, 3_000, 1),
                new Student("Khaled", "Mohanad", 23, 10_000, 1),
                new Student("Wegz", "Pablo", 28, 2_000, 2),
                new Student("Samia", "Ahmed", 36, 5_000, 2),
                new Student("Reham", "El komy", 25, 15_000, 3),
                new Student("sameh", "nashaat", 55, 120_000, 3),
                new Student("dwla", "el dawly", 45, 200_000, 4)
            };
        }

        public static List<Track> GetTracks()
        {
            return new List<Track>()
            {
                new Track("Backend"),
                new Track("Frontend"),
                new Track("DevOps"),
                new Track("Network")
            };
        }
    }
}
