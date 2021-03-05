using System;
using System.Collections.Generic;

namespace GamerProject.Entities
{
    public class Gamer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public float Budget { get; set; }
        public List<Game> BoughtGames { get; set; }
        public List<Campaign> UsedCampaigns { get; set; }
    }
}