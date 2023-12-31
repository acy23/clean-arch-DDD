﻿using karavana_CONTRACTS.DTOs.CaravanRentOffer;
using karavana_CONTRACTS.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace karavana_CONTRACTS.DTOs.Rating
{
    public class RatingDto
    {
        public string UserId { get; set; }
        public UserDto User { get; set; }
        public double Rate { get; set; }
        public string? Comment { get; set; }
        public CaravanRentOfferDto CaravanRentOffer { get; set; }
        public int CaravanRentOfferId { get; set; }
    }
}
