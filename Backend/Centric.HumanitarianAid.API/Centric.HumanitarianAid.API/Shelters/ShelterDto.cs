namespace Centric.HumanitarianAid.API.Shelters
{
    public class ShelterDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int RemainingNumberOfPlaces { get; set; }

        public string OwnerName { get; set; }

        public string OwnerEmail { get; set; }

        public string OwnerPhone { get; set; }

        public DateTime RegistrationDateTime { get; set; }
    }
}