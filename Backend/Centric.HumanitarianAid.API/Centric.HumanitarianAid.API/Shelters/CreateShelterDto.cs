﻿namespace HumanitarianAid.API.Shelters
{
	public class CreateShelterDto
	{
        public string Name { get; set; }

        public string Address { get; set; }

        public int NumberOfPlaces { get; set; }

        public string OwnerName { get; set; }

        public string OwnerEmail { get; set; }

        public string OwnerPhone { get; set; }
    }
}
