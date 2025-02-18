﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using GigHub.Controllers;
using GigHub.Models;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        public int Id { get; set; }

        [Required] public string Venue { get; set; }

        [Required] [FutureDate] public string Date { get; set; }

        [Required] [ValidTime] public string Time { get; set; }

        [Required] public byte Genre { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<GigsController, ActionResult>> update = c => c.Update(this);
                Expression<Func<GigsController, ActionResult>> create = c => c.Create(this);

                var action = Id != 0 ? update : create;
                var actionName = ((MethodCallExpression) action.Body).Method.Name;

                return actionName;
            }
        }

        public DateTime GetDateTime()
        {
            return DateTime.Parse($"{Date} {Time}");
        }
    }
}