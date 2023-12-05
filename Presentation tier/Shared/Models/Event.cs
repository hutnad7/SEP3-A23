<<<<<<< Updated upstream:Presentation tier/Cafe/Models/Event.cs
﻿namespace Cafe.Models;
=======
﻿using System.Text.Json.Serialization;

namespace Shared.Models;
>>>>>>> Stashed changes:Presentation tier/Shared/Models/Event.cs

public class Event
{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid EntertainerId { get; set; }
        public Guid CafeOwnerId { get; set; }
        public DateTime Date { get; set; }
        public int AvailablePlaces { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
}