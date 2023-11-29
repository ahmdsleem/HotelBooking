﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Models
{
    public class Reservation
    {
        public RoomID RoomID { get; }
        public string UserName {  get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }

        public TimeSpan Length => EndTime.Subtract(StartTime);

        public Reservation(RoomID roomID,string userName, DateTime startTime, DateTime endTime)
        {
            RoomID = roomID;
            UserName = userName;
            StartTime = startTime;
            EndTime = endTime;
        }

        internal bool Conflict(Reservation reservation)
        {
            if (reservation.RoomID != RoomID)
            {
                return false;
            }

            return reservation.StartTime < EndTime || reservation.EndTime > StartTime;
        }
    }
}