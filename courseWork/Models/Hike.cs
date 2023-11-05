using SQLite;
using System;
namespace courseWork.Models
{
    public class Hike
    {
        public Hike ()
        {
            DateStart = DateTime.Now;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime DateStart { get; set; }
        public bool IsPacking { get; set; }
        public double LengthOfHike { get; set; }
        public string LevelOfDifficulty { get; set; }
        public string Description { get; set; }

        public Hike Clone() => MemberwiseClone() as Hike;

        public (bool IsValid, string? ErrorMessage) Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return (false, $"{nameof(Name)} is required.");
            }
            else if (string.IsNullOrWhiteSpace(Location))
            {
                return (false, $"{nameof(Location)} is required.");
            }
            else if (LengthOfHike <= 0)
            {
                return (false, $"{nameof(LengthOfHike)} should be greater than 0.");
            }
            else if (DateStart == DateTime.MinValue)
            {
                return (false, $"{nameof(DateStart)} is required.");
            }
            else if (string.IsNullOrWhiteSpace(LevelOfDifficulty))
            {
                return (false, $"{nameof(LevelOfDifficulty)} is required.");
            }
         
            return (true, null);

        }
    }
}
